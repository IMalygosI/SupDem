using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Microsoft.EntityFrameworkCore;
using SuperDemo_21_01_2025.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperDemo_21_01_2025
{
    public partial class MainWindow : Window
    {
        List<Tovar> tovars = new List<Tovar>();
        public MainWindow()
        {
            InitializeComponent();

            PriceBox.SelectionChanged += PriceBox_SelectionChanged;
            DiscountBox.SelectionChanged += DiscountBox_SelectionChanged;

            Loaded();
        }

        public new void Loaded() 
        {
            tovars = Helper.DataBase.Tovars.Include(d => d.Manufacturer).ToList();

            if (DiscountBox.SelectedIndex == 1)
            {
                tovars = tovars.Where(s => s.Discount >= 0 & s.Discount <= 9.99).ToList();
            }
            else if (DiscountBox.SelectedIndex == 2)
            {
                tovars = tovars.Where(s => s.Discount >= 10 & s.Discount <= 14.99).ToList();
            }
            else if (DiscountBox.SelectedIndex == 3)
            {
                tovars = tovars.Where(s => s.Discount >= 15).ToList();
            }

            if (PriceBox.SelectedIndex == 1) 
            {
                tovars = tovars.OrderByDescending(s =>s.Price2).ToList();
            }
            else if (PriceBox.SelectedIndex == 2)
            {
                tovars = tovars.OrderBy(s => s.Price2).ToList();
            }

            var search = (SearchTexxt.Text ?? "").Split(' ');
            tovars = tovars.Where(s => search.All(dd => s.Name.Contains(dd)
                                                 )).ToList();

            Vsego.Text = Helper.DataBase.Tovars.Count().ToString();
            Pokaz.Text = tovars.Count().ToString();

            ListBox_Vivo.ItemsSource = tovars;
        }
        private void PriceBox_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loaded();
        private void DiscountBox_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loaded();
        private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loaded();

        private void ListBox_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var redact = ListBox_Vivo.SelectedItem as Tovar;
            Redact redact1 = new Redact(redact);
            redact1.Show();
            Close();
        }

        private void Button_Click_Dobavit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Redact redact1 = new Redact();
            redact1.Show();
            Close();
        }

        private void Button_Click_Delete(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var delet = ListBox_Vivo.SelectedItem as Tovar;
            Helper.DataBase.Tovars.Remove(delet);
            Helper.DataBase.SaveChanges();
            Loaded();
        }
    }
}
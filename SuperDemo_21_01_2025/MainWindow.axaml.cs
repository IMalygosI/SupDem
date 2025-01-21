using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using SuperDemo_21_01_2025.Models;
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


        public void Loaded() 
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
            else if(DiscountBox.SelectedIndex == 3)
            {
                tovars = tovars.Where(s => s.Discount == 15).ToList();
            }
            else if (DiscountBox.SelectedIndex == 4)
            {
                tovars = tovars.Where(s => s.Discount > 15).ToList();
            }

            if (PriceBox.SelectedIndex == 1) 
            {
                tovars = tovars.OrderByDescending(s =>s.Price).ToList();
            }
            else if (PriceBox.SelectedIndex == 2)
            {
                tovars = tovars.OrderBy(s => s.Price).ToList();
            }

            Vsego.Text = Helper.DataBase.Tovars.Count().ToString();
            Pokaz.Text = tovars.Count().ToString();

            ListBox_Vivo.ItemsSource = tovars;
        }
        private void PriceBox_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loaded();
        private void DiscountBox_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loaded();
    }
}
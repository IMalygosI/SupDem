using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using SkiaSharp;
using SuperDemo_21_01_2025.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperDemo_21_01_2025;

public partial class Redact : Window
{
    List<EdIzmerenium> edIzmerenia = new List<EdIzmerenium>();
    List<Manufacturer> manufacturers = new List<Manufacturer>();
    List<Categoty> categoties = new List<Categoty>();
    List<Postavshic> postavshics = new List<Postavshic>();

    Tovar tovars;
    decimal price;
    string names;
    string Articгuls;
    string description;
    Bitmap images;
    int maxSkidka;
    int discount;
    int count;

    public Redact()
    {
        InitializeComponent();
        tovars = new Tovar();

        Loang_ComboBoxManufacturer();
        Loang_ComboBoxPostavshic();
        Loang_ComboBoxCategory();
        Loang_ComboBoxedIzmerenia();
    }
    public Redact(Tovar tovar)
    {
        InitializeComponent();

        tovars = tovar;

        names = tovar.Name;
        Articгuls = tovar.Articгul;
        description = tovar.Description;
        images = tovar.image;

        price = tovar.Price;
        maxSkidka = tovar.MaxSkidka;
        discount = tovar.Discount;
        count = tovar.Count;


        Loang_ComboBoxManufacturer();
        Loang_ComboBoxPostavshic();
        Loang_ComboBoxCategory();
        Loang_ComboBoxedIzmerenia();

        Redact_Grid.DataContext = tovars;
    }

    public void Loang_ComboBoxedIzmerenia()
    {
        if (tovars.TovarId != 0)
        {
            edIzmerenia = Helper.DataBase.EdIzmerenia.ToList();
            EdIzmer.ItemsSource = edIzmerenia.OrderByDescending(f => f.EdIzmereniaId == tovars.EdIzmerenia);
            EdIzmer.SelectedIndex = 0;
        }
        else
        {
            edIzmerenia = Helper.DataBase.EdIzmerenia.ToList();
            edIzmerenia.Add(new EdIzmerenium() { Name = "Выбрать единицу измерения" });
            EdIzmer.ItemsSource = edIzmerenia.OrderByDescending(f => f.Name == "Выбрать единицу измерения");
            EdIzmer.SelectedIndex = 0;
        }
    }
    public void Loang_ComboBoxCategory()
    {
        if (tovars.TovarId != 0)
        {
            categoties = Helper.DataBase.Categoties.ToList();
            Categor.ItemsSource = categoties.OrderByDescending(f => f.CategotyId == tovars.CategotyId);
            Categor.SelectedIndex = 0;
        }
        else
        {
            categoties = Helper.DataBase.Categoties.ToList();
            categoties.Add(new Categoty() { Name = "Выбрать категорию" });
            Categor.ItemsSource = categoties.OrderByDescending(f => f.Name == "Выбрать категорию");
            Categor.SelectedIndex = 0;
        }
    }
    public void Loang_ComboBoxPostavshic()
    {
        if (tovars.TovarId != 0)
        {
            postavshics = Helper.DataBase.Postavshics.ToList();
            Postav.ItemsSource = postavshics.OrderByDescending(f => f.PostavshicId == tovars.PostavshicId);
            Postav.SelectedIndex = 0;
        }
        else
        {
            postavshics = Helper.DataBase.Postavshics.ToList();
            postavshics.Add(new Postavshic() { Name = "Выбрать поставщика" });
            Postav.ItemsSource = postavshics.OrderByDescending(f => f.Name == "Выбрать поставщика");
            Postav.SelectedIndex = 0;
        }
    }
    public void Loang_ComboBoxManufacturer()
    {
        if (tovars.TovarId != 0)
        {
            manufacturers = Helper.DataBase.Manufacturers.ToList();

            Manufactur.ItemsSource = manufacturers.OrderByDescending(f => f.ManufacturerId == tovars.ManufacturerId);
            Manufactur.SelectedIndex = 0;
        }
        else
        {
            manufacturers = Helper.DataBase.Manufacturers.ToList();
            manufacturers.Add(new Manufacturer() { Name = "Выбрать производителя" });
            Manufactur.ItemsSource = manufacturers.OrderByDescending(f => f.Name == "Выбрать производителя");
            Manufactur.SelectedIndex = 0;
        }
    }

    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Name.Text = names;
        Articгul.Text = Articгuls;
        Description.Text = description;
        Images.Source = images;

        MaxSkidka.Text = (maxSkidka).ToString();
        Price.Text = (price).ToString();
        Discount.Text = (discount).ToString();
        Count.Text = (count).ToString();

        Manufactur.SelectedIndex = (0);
        Postav.SelectedIndex = (0);
        Categor.SelectedIndex = (0);
        EdIzmer.SelectedIndex = (0);

        MainWindow mainWindow = new MainWindow();   
        mainWindow.Show();
        Close();
    }

    private void Button_Click_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool test = false;
        if (tovars.TovarId != 0)
        {
            if (EdIzmer.SelectedItem is EdIzmerenium izmerenium) 
            {
                tovars.EdIzmerenia = izmerenium.EdIzmereniaId;
            }
            if (Categor.SelectedItem is Categoty categoty)
            {
                tovars.CategotyId = categoty.CategotyId;
            }
            if (Postav.SelectedItem is Postavshic postavshic)
            {
                tovars.PostavshicId = postavshic.PostavshicId;
            }
            if (Manufactur.SelectedItem is Manufacturer manufacturer)
            {
                tovars.ManufacturerId = manufacturer.ManufacturerId;
            }

            test = true;

            Helper.DataBase.Tovars.Update(tovars);
        }
        else 
        {
            tovars.Name = Name.Text;
            tovars.Description = Description.Text;
            tovars.Articгul = Articгul.Text;
            tovars.Count = Convert.ToInt32(Count.Text);
            tovars.MaxSkidka = Convert.ToInt32(MaxSkidka.Text);
            tovars.Discount = Convert.ToInt32(Discount.Text);
            tovars.Price = Convert.ToDecimal(Price.Text);
            tovars.EdIzmerenia = EdIzmer.SelectedIndex;
            tovars.ManufacturerId = Manufactur.SelectedIndex;
            tovars.CategotyId = Categor.SelectedIndex;
            tovars.PostavshicId = Postav.SelectedIndex;

            Helper.DataBase.Tovars.Add(tovars);
        }
        // для проверки на наличие совпадающих артикулов
        bool ProverkaOnArticle = true;
        //Ищем совпадающие артикулы
        foreach (Tovar tovaar in Helper.DataBase.Tovars)
        {
            // если нашли 
            if (Articгul.Text == tovaar.Articгul)
            {
                // ставим false
                ProverkaOnArticle = false;
                break;
            }
        }

        if (ProverkaOnArticle != null)
        {
            if (ProverkaOnArticle == true || test == true)
            {
                if (tovars.Name != null)
                {
                    if (tovars.Price != null)
                    {
                        if (tovars.Price > 0)
                        {
                            if (tovars.MaxSkidka != null)
                            {
                                if (tovars.MaxSkidka >= 0 & tovars.MaxSkidka > tovars.Discount)
                                {
                                    if (tovars.Discount != null)
                                    {
                                        if (tovars.Discount >= 0)
                                        {
                                            if (tovars.Count != null)
                                            {
                                                if (tovars.Count >= 0)
                                                {
                                                    if (tovars.EdIzmerenia > 0)
                                                    {
                                                        if (tovars.CategotyId > 0)
                                                        {
                                                            if (tovars.ManufacturerId > 0)
                                                            {
                                                                if (tovars.PostavshicId > 0)
                                                                {
                                                                    Helper.DataBase.SaveChanges();
                                                                    MainWindow mainWindow = new MainWindow();
                                                                    mainWindow.Show();
                                                                    Close();
                                                                }
                                                                else
                                                                {
                                                                    string errors = "Выберите поставщика!";
                                                                    Error error = new Error(errors);
                                                                    error.ShowDialog(this);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                string errors = "Выберите производителя!";
                                                                Error error = new Error(errors);
                                                                error.ShowDialog(this);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            string errors = "Выберите категорию!";
                                                            Error error = new Error(errors);
                                                            error.ShowDialog(this);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string errors = "Выберите единицу измерения!";
                                                        Error error = new Error(errors);
                                                        error.ShowDialog(this);
                                                    }
                                                }
                                                else
                                                {
                                                    string errors = "Количество товара не может быть отрицательным!";
                                                    Error error = new Error(errors);
                                                    error.ShowDialog(this);
                                                }
                                            }
                                            else
                                            {
                                                string errors = "Введите количество товара!";
                                                Error error = new Error(errors);
                                                error.ShowDialog(this);
                                            }
                                        }
                                        else
                                        {
                                            string errors = "Скидка не может быть отрицательной!";
                                            Error error = new Error(errors);
                                            error.ShowDialog(this);
                                        }
                                    }
                                    else
                                    {
                                        string errors = "Введите скидку!";
                                        Error error = new Error(errors);
                                        error.ShowDialog(this);
                                    }
                                }
                                else
                                {
                                    string errors = "Максимальная скидка не может быть отрицательной и не может быть меньше активной скидки";
                                    Error error = new Error(errors);
                                    error.ShowDialog(this);
                                }
                            }
                            else
                            {
                                string errors = "Введите максимальную скидку!";
                                Error error = new Error(errors);
                                error.ShowDialog(this);
                            }
                        }
                        else
                        {
                            string errors = "Цена не может быть отрицательной и равна 0!";
                            Error error = new Error(errors);
                            error.ShowDialog(this);
                        }
                    }
                    else
                    {
                        string errors = "Введите цену!";
                        Error error = new Error(errors);
                        error.ShowDialog(this);
                    }
                }
                else
                {
                    string errors = "Введите наименование!";
                    Error error = new Error(errors);
                    error.ShowDialog(this);
                }
            }
            else
            {
                string errors = "Артикул уже занят!";
                Error error = new Error(errors);
                error.ShowDialog(this);
            }
        }
        else 
        {
            string errors = "Отсутствует артикул!";
            Error error = new Error(errors);
            error.ShowDialog(this);
        }

    }
    private readonly FileDialogFilter fileFilter = new()
    {
        Extensions = new List<string>() { "png", "jpg", "jpeg" }
    };
    private async void Button_Click_Image(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(fileFilter);
            var result = await dialog.ShowAsync(this);
            string file = String.Join("", result);
            long length = new System.IO.FileInfo(file).Length;
            Random random = new Random();
            string photo = "Assets/photo" + random.Next(1, 10808) + ".jpg";
            System.IO.File.Copy(file, photo);
            Images.Source = new Bitmap(photo);
            tovars.Picture = photo.Substring(6);
        }
        catch { }
    }
}
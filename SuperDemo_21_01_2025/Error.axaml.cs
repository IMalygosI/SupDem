using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SuperDemo_21_01_2025;

public partial class Error : Window
{
    public Error()
    {
        InitializeComponent();
    }
    public Error(string Warnings)
    {
        InitializeComponent();
        if (Warnings == "Отсутствует артикул!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Артикул уже занят!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Введите наименование!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Введите цену!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Цена не может быть отрицательной и равна 0!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Введите максимальную скидку!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Максимальная скидка не может быть отрицательной и не может быть меньше активной скидки")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Введите скидку!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Скидка не может быть отрицательной!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Введите количество товара!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Количество товара не может быть отрицательным!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Выберите единицу измерения!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Выберите категорию!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Выберите производителя!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "Выберите поставщика!")
        {
            Warning.Text = Warnings;
        }
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}
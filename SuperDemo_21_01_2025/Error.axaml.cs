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
        if (Warnings == "����������� �������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������� ��� �����!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������� ������������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������� ����!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "���� �� ����� ���� ������������� � ����� 0!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������� ������������ ������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������������ ������ �� ����� ���� ������������� � �� ����� ���� ������ �������� ������")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������� ������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������ �� ����� ���� �������������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������� ���������� ������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "���������� ������ �� ����� ���� �������������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "�������� ������� ���������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "�������� ���������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "�������� �������������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "�������� ����������!")
        {
            Warning.Text = Warnings;
        }
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}
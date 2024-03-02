using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для TestUI.xaml
    /// </summary>
    public partial class TestUI : Window
    {
        public TestUI()
        {
            InitializeComponent();
            Tables.ItemsSource = new List<string>() { "first table", "SECOND TABLE", "third Table" };
            DataGrid.ItemsSource = new List<Human>() 
            { 
                new Human() { Id = 1, Name = "Valera", Description = "cool dude" },
                new Human() { Id = 2, Name = "Sasha", Description = "also cool dude"},
                new Human() { Id = 3, Name = "Petr", Description = "rude" }
            };
        }
    }

    public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}

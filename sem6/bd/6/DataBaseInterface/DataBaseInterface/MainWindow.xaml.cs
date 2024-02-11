using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBaseInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Table> tables = new ObservableCollection<Table>();

        public MainWindow()
        {
            InitializeComponent();

            //names = new ObservableCollection<string>() { "John", "Alex", "Sam",};
            //TablesListView.ItemsSource = names;
            

            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("id");
            dataTable1.Columns.Add("name");
            dataTable1.Columns.Add("surname");
            dataTable1.Rows.Add(new object[] { 1, "Kirill", "Bebrikov" });
            dataTable1.Rows.Add(new object[] { 2, "Artyom", "Grib" });

            DataTable dataTable2 = new DataTable();
            dataTable2.Columns.Add("id");
            dataTable2.Columns.Add("name");
            dataTable2.Columns.Add("birthday");
            dataTable2.Columns.Add("age");
            dataTable2.Rows.Add(new object[] { 1, "gleb", "16-16-2016", 22 });

            Table table = new Table();
            table.Name = "test table";
            table.DataTable = dataTable1;

            Table table1 = new Table();
            table.Name = "test table2";
            table1.DataTable = dataTable2; 

            ObservableCollection<Table> tables = new ObservableCollection<Table>();

            tables.Add(table);
            tables.Add(table1);
            TablesListView.ItemsSource = tables;

            foreach (var item in TablesListView.Items)
            {
                //((ListViewItem)item).DataContext = "123";
            }
            //TablesListView.SelectedItem;
            //dataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = ((Table)TablesListView.SelectedItem).DataTable.DefaultView;
            
            //names.Add(textbox.Text);
            //ObservableCollection<string> s = new ObservableCollection<string>();
        }

        private void TablesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

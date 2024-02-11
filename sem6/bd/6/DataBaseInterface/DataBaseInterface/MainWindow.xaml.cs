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
        //ObservableCollection<DataTable> tables = new ObservableCollection<DataTable>();
        private Dictionary<string, DataTable> tablesNamesDictionary = new Dictionary<string, DataTable>();
        private ObservableCollection<string> tablesNames = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

            //names = new ObservableCollection<string>() { "John", "Alex", "Sam",};
            //TablesListView.ItemsSource = names;
            TablesListView.ItemsSource = tablesNames;

            DataTable Workers = new DataTable();
            Workers.Columns.Add("id");
            Workers.Columns.Add("name");
            Workers.Columns.Add("birthday");
            Workers.Columns.Add("age");
            Workers.Columns.Add("speciality_id");
            Workers.Rows.Add(new object[] { 1, "Kirill", "1999-5-5", 22, 1});
            Workers.Rows.Add(new object[] { 2, "Mihail", "1998-6-8", 21, 4 });
            Workers.Rows.Add(new object[] { 3, "John", "1999-1-5", 22, 3 });
            Workers.Rows.Add(new object[] { 4, "Ivan", "2000-9-7", 22, 1 });
            Workers.Rows.Add(new object[] { 5, "Petr", "2001-12-12", 22, 2 });

            DataTable Speciality = new DataTable();
            Speciality.Columns.Add("id");
            Speciality.Columns.Add("name");
            Speciality.Columns.Add("salary");
            Speciality.Rows.Add(new object[] { 1, "slesar", 200});
            Speciality.Rows.Add(new object[] { 2, "yborshik", 150 });
            Speciality.Rows.Add(new object[] { 3, "youtuber", 400 });
            Speciality.Rows.Add(new object[] { 4, "programmer", 500 });
            Speciality.Rows.Add(new object[] { 5, "mehanik", 300 });

            tablesNames.Add("Workers");
            tablesNames.Add("Speciality");
            tablesNamesDictionary.Add("Workers", Workers);
            tablesNamesDictionary.Add("Speciality", Speciality);
        }

        private void ViewTableButton_Click(object sender, RoutedEventArgs e)
        {
            if (TablesListView.SelectedItem != null)
                dataGrid.ItemsSource = tablesNamesDictionary[((string)TablesListView.SelectedItem)].DefaultView;
        }

        private void TablesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

using DataBaseInterface.DataTables;
using DataBaseInterface.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
        private Dictionary<string, DataTable> _tablesDictionary = new Dictionary<string, DataTable>();
        private ObservableCollection<string> _tablesNames = new ObservableCollection<string>();
        public string SelectedDataTableKey { get; set; }
        public Dictionary<string, DataTable> TablesNamesDictionary { get =>  _tablesDictionary; }


		public Dictionary<string, object> _dbTablesDictionary = new Dictionary<string, object>();
		private IS_Buro_KadrovContext _db = new IS_Buro_KadrovContext();
        public MainWindow()
        {
            InitializeComponent();
			

			//db.Specialities.Add(new Speciality() { SpecialityName = "Дворник" });
			//db.SaveChanges();

			_tablesNames.Add("Encouragements");
			_tablesNames.Add("Speciality");
			_tablesNames.Add("Department");

			_dbTablesDictionary.Add("Encouragements", _db.Encouragements.ToList());
			_dbTablesDictionary.Add("Speciality", _db.Specialities.ToList());
			_dbTablesDictionary.Add("Department", _db.Departments.ToList());

			//_db.Contracts.Add();
			dataGrid.ItemsSource = _db.Encouragements.ToList();
			TablesListView.ItemsSource = _tablesNames;//_tablesNames;

			//DataTable Workers = new DataTable();
			//Workers.Columns.Add("id");
			//Workers.Columns.Add("name");
			//Workers.Columns.Add("birthday");
			//Workers.Columns.Add("age");
			//Workers.Columns.Add("speciality_id");
			//Workers.Rows.Add(new object[] { 1, "Kirill", "1999-5-5", 22, 1 });
			//Workers.Rows.Add(new object[] { 2, "Mihail", "1998-6-8", 21, 4 });
			//Workers.Rows.Add(new object[] { 3, "John", "1999-1-5", 22, 3 });
			//Workers.Rows.Add(new object[] { 4, "Ivan", "2000-9-7", 22, 1 });
			//Workers.Rows.Add(new object[] { 5, "Petr", "2001-12-12", 22, 2 });

			//DataTable Speciality = new DataTable();
			//Speciality.Columns.Add("id");
			//Speciality.Columns.Add("name");
			//Speciality.Columns.Add("salary");
			//Speciality.Rows.Add(new object[] { 1, "slesar", 200 });
			//Speciality.Rows.Add(new object[] { 2, "yborshik", 150 });
			//Speciality.Rows.Add(new object[] { 3, "youtuber", 400 });
			//Speciality.Rows.Add(new object[] { 4, "programmer", 500 });
			//Speciality.Rows.Add(new object[] { 5, "mehanik", 300 });

			//_tablesNames.Add("Workers");
			//_tablesNames.Add("Speciality");
			//_tablesDictionary.Add("Workers", Workers);
			//_tablesDictionary.Add("Speciality", Speciality);
		}

        private void EditRowButton_Click(object sender, RoutedEventArgs e)
        {
            //if (TablesListView.SelectedItem != null)
            //    dataGrid.ItemsSource = tablesNamesDictionary[((string)TablesListView.SelectedItem)].DefaultView;
            int editingRow = dataGrid.SelectedIndex;
            if (editingRow == -1)
                return;

            ObservableCollection<EditField> editingFields = new ObservableCollection<EditField>();

			int i = 0;
			//var element = dataGrid.Items[dataGrid.SelectedIndex];
			foreach (var cell in dataGrid.SelectedCells)
			{
				
				editingFields.Add(new EditField() { Name = cell.Column.Header.ToString(), Content = (cell.Item).ToString() });
				i++;
			}

			//foreach (var item in dataGrid.SelectedItems)
			//{
			//	editingFields.Add(new EditField() { Content = item.ToString() });
			//}

			RowEditWindow editWindow = new RowEditWindow(editingFields, editingRow);
			editWindow.Show();
		}

        private void TablesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

			SelectedDataTableKey = TablesListView.SelectedItem.ToString();

            if (SelectedDataTableKey == null)
                return;

			dataGrid.ItemsSource = (IEnumerable)_dbTablesDictionary[SelectedDataTableKey];

            //if (TablesListView.SelectedItem != null)
            //    dataGrid.ItemsSource = _tablesDictionary[SelectedDataTableKey].DefaultView;

			//lb.Content = TablesListView.SelectedItem.ToString();////
		}

		private void addButton_Click(object sender, RoutedEventArgs e)
		{
            ObservableCollection<EditField> addFields = new ObservableCollection<EditField>();

			foreach (var column in dataGrid.Columns)
			{
				addFields.Add(new EditField() { Name = column.Header.ToString() , Content = ""});
			}

			RowAddWindow addWindow = new RowAddWindow(addFields);
            addWindow.Show();
		}

		private void deleteButton_Click(object sender, RoutedEventArgs e)
		{
            if (dataGrid.SelectedIndex ==  -1) 
                return;

            _tablesDictionary[SelectedDataTableKey].Rows[dataGrid.SelectedIndex].Delete();
		}

		private void viewButtonClick(object sender, RoutedEventArgs e)
		{
			switch(SelectedDataTableKey)
			{
				case "Encouragements":
					new EncouragementWindow(_db).Show();
					break;
			}
		}
	}
}

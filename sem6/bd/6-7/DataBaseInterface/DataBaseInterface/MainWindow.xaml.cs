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
using System.Runtime.CompilerServices;
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
        public string SelectedTable { get; set; }
        public Dictionary<string, DataTable> TablesNamesDictionary { get =>  _tablesDictionary; }


		public Dictionary<string, object> _dbTablesDictionary = new Dictionary<string, object>();
		private IS_Buro_KadrovContext _db = new IS_Buro_KadrovContext();
        public MainWindow()
        {
            InitializeComponent();

			_tablesNames.Add("Encouragements");
			_tablesNames.Add("Speciality");
			_tablesNames.Add("Department");

			//_dbTablesDictionary.Add("Encouragements", _db.Encouragements.ToList());
			//_dbTablesDictionary.Add("Speciality", _db.Specialities.ToList());
			//_dbTablesDictionary.Add("Department", _db.Departments.ToList());

			//_db.Contracts.Add();
			//dataGrid.ItemsSource = _db.Encouragements.ToList();

			//foreach(var column in dataGrid.Columns)
			//{
			//	if (column.Header.ToString() == "Id") column.Visibility = Visibility.Hidden;
			//}

			TablesListView.ItemsSource = _tablesNames;
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

			//dataGrid.ItemsSource = _db.Encouragements.ToList();
			SelectedTable = TablesListView.SelectedItem.ToString();

            if (SelectedTable == null)
                return;

			
			//dataGrid.ItemsSource = (IEnumerable)_dbTablesDictionary[SelectedDataTableKey];
			UpdateDataGrid();
			HideId(dataGrid);

			//if (TablesListView.SelectedItem != null)
			//    dataGrid.ItemsSource = _tablesDictionary[SelectedDataTableKey].DefaultView;

			//lb.Content = TablesListView.SelectedItem.ToString();////
		}

		private void AddButtonClick(object sender, RoutedEventArgs e)
		{
			switch(SelectedTable)
			{
				case "Encouragements":
					new AddEncouragementWindow(_db).Show();
					break;
			}
		}

		private void DeleteButtonClick(object sender, RoutedEventArgs e)
		{
            if (dataGrid.SelectedIndex == -1) 
                return;

			switch (SelectedTable)
			{
				case "Encouragements":
					var deletingEncouragement = _db.Encouragements.Where(enc => enc.Id == ((Encouragement)dataGrid.SelectedItems[0]).Id).Single();
					_db.Encouragements.Remove(deletingEncouragement);
					break;
				case "Speciality":
					var deletingSpeciality = _db.Specialities.Where(enc => enc.Id == ((Speciality)dataGrid.SelectedItems[0]).Id).Single();
					_db.Specialities.Remove(deletingSpeciality);
					break;
				case "Department":
					var deletingDepartment = _db.Departments.Where(enc => enc.Id == ((Department)dataGrid.SelectedItems[0]).Id).Single();
					_db.Departments.Remove(deletingDepartment);
					break;
			}
			_db.SaveChanges();
			UpdateDataGrid();
			//_tablesDictionary[SelectedDataTableKey].Rows[dataGrid.SelectedIndex].Delete();
		}

		private void viewButtonClick(object sender, RoutedEventArgs e)
		{

			switch (SelectedTable)
			{
				case "Encouragements":
					new EncouragementWindow(_db).Show();
					break;
			}
		}

		public void HideId(DataGrid dataGrid)
		{
			foreach (var column in dataGrid.Columns)
			{
				if (column.Header.ToString() == "Id") column.Visibility = Visibility.Hidden;
			}
			dataGrid.Items.Refresh();
		}
		public void UpdateDataGrid()
		{
			dataGrid.ItemsSource = null;
			switch(SelectedTable)
			{
				case "Encouragements":
					dataGrid.ItemsSource = _db.Encouragements.ToList();
					break;
				case "Speciality":
					dataGrid.ItemsSource = _db.Specialities.ToList();
					break;
				case "Department":
					dataGrid.ItemsSource = _db.Departments.ToList();
					break;
			}
			//dataGrid.ItemsSource = (IEnumerable)_dbTablesDictionary[SelectedDataTableKey];
			HideId(dataGrid);
		}
	}
}

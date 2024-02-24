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
        private ObservableCollection<string> _tablesNames = new ObservableCollection<string>();
        public string? SelectedTable { get; set; }
       

		public Dictionary<string, object> _dbTablesDictionary = new Dictionary<string, object>();
		private IS_Buro_KadrovContext _db = new IS_Buro_KadrovContext();
        public MainWindow()
        {
            InitializeComponent();

			_tablesNames.Add("Encouragements");
			_tablesNames.Add("Speciality");
			_tablesNames.Add("Department");
			_tablesNames.Add("Directors");
			_tablesNames.Add("Company");

			TablesListView.ItemsSource = _tablesNames;
		}

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex == -1)
                return;

			switch (SelectedTable)
			{
				case "Encouragements":
					new EncouragementWindow(_db, ((Encouragement)dataGrid.SelectedItems[0]).Id).Show();
					break;
				case "Directors":
					new DirectorWindow(_db, ((Director)dataGrid.SelectedItems[0]).Id).Show();
					break;
			}

			UpdateDataGrid();
		}

        private void TablesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			SelectedTable = TablesListView.SelectedItem.ToString();
            if (SelectedTable == null)
                return;

			UpdateDataGrid();
			HideId(dataGrid);
		}

		private void AddButtonClick(object sender, RoutedEventArgs e)
		{
			switch(SelectedTable)
			{
				case "Encouragements":
					new EncouragementWindow(_db).Show();
					break;
				case "Directors":
					new DirectorWindow(_db).Show();
					break;
				case "Company":
					new CompanyWindow(_db).Show();
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
				case "Directors":
					var deletingDirector = _db.Directors.Where(enc => enc.Id == ((Director)dataGrid.SelectedItems[0]).Id).Single();
					_db.Directors.Remove(deletingDirector);
					break;
				case "Company":
					var deletingCompany = _db.Companies.Where(comp => comp.Id == ((Company)dataGrid.SelectedItems[0]).Id).Single();
					_db.Companies.Remove(deletingCompany);
					break;

			}
			_db.SaveChanges();
			UpdateDataGrid();
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
				case "Directors":
					dataGrid.ItemsSource = _db.Directors.ToList();
					break;
				case "Company":
					dataGrid.ItemsSource = _db.Companies.ToList();
					break;
			}
			HideId(dataGrid);
		}

		private void viewButton_Click(object sender, RoutedEventArgs e)
		{
			var table = from a in _db.Encouragements
						where a.Id % 2 == 0
						select a;
			dataGrid.ItemsSource = table.ToList();
		}
	}
}

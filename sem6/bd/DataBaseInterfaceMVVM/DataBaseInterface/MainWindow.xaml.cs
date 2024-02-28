using DataBaseInterface.Windows;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DataBaseInterface.ViewModels;

namespace DataBaseInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private ObservableCollection<string> _tablesNames = new ObservableCollection<string>();
		private IS_Buro_KadrovContext _db = IS_Buro_KadrovContext.GetInstance();
		private TestFilterPage _filterPage = new TestFilterPage();
		public Page Page { get; set; }
		
        public string? SelectedTable { get; set; }
        public MainWindow()
        {
            InitializeComponent();
			DataContext = new ApplicationViewModel();
		}

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex == -1)
                return;

			switch (SelectedTable)
			{
				case "Directors":
					new DirectorWindow(_db, ((Director)dataGrid.SelectedItems[0]).Id).Show();
					break;
				case "Company":
					new CompanyWindow(_db, ((Company)dataGrid.SelectedItems[0]).Id).Show();
					break;
			}

			//UpdateDataGrid();
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
			//filterFrame.Content = null;
			filterFrame.Visibility = Visibility.Hidden;
			switch(SelectedTable)
			{
				case "Encouragements":

					dataGrid.ItemsSource = _db.Encouragements.ToList();
					filterFrame.Visibility = Visibility.Visible;
					filterFrame.Content = _filterPage;
					UpdateTestFilters();
					break;
				case "Speciality":
					dataGrid.ItemsSource = _db.Specialities.ToList();
					break;
				case "Department":
					dataGrid.ItemsSource = _db.Departments.ToList();
					break;
				case "Directors":

					//if (checkBox.IsChecked == true)
					//dataGrid.ItemsSource = _db.Directors.Where(dir => dir.LastName == "Ковалёв").ToList();
					//else
					dataGrid.ItemsSource = _db.Directors.ToList();
					break;
				case "Company":
					dataGrid.ItemsSource = _db.Companies.ToList();
					break;
			}
			//HideId(dataGrid);
		}

		public void UpdateTestFilters()
		{
			//((TestFilterPage)Page).checkbox1

			var encouragements = _db.Encouragements;
			var collection = _db.Encouragements.ToList();

			if (_filterPage.checkbox1.IsChecked == true)
			{
				collection = encouragements.Where(enc => enc.Id % 2 == 0).ToList();
			}
			if (_filterPage.checkbox2.IsChecked == true)
				collection = collection.Where(enc => enc.Id > 2).ToList();

			dataGrid.ItemsSource = collection;
		}
	}
}

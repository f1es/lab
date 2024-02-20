using DataBaseInterface.Entities;
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

namespace DataBaseInterface.DataTables
{
	/// <summary>
	/// Логика взаимодействия для EncouragementWindow.xaml
	/// </summary>
	public partial class EncouragementWindow : Window
	{
		private IS_Buro_KadrovContext _db;
		public EncouragementWindow(IS_Buro_KadrovContext db)
		{
			InitializeComponent();

			dataGrid.ItemsSource = db.Encouragements.ToList();
			_db = db;
			UpdateDataGrid();
			
		}
		private void CloseButtonClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void AddButtonClick(object sender, RoutedEventArgs e)
		{
			new AddEncouragementWindow(_db).Show();
		}

		private void DeleteButtonClick(object sender, RoutedEventArgs e)
		{
			int selectedId = ((Encouragement)dataGrid.SelectedItems[0]).Id;
			var deletingEncouragement = _db.Encouragements.Where(enc => enc.Id == selectedId).Single();
			_db.Encouragements.Remove(deletingEncouragement);
			_db.SaveChanges();
			UpdateDataGrid();
		}

		public void UpdateDataGrid()
		{
			dataGrid.ItemsSource = null;
			dataGrid.ItemsSource = _db.Encouragements.ToList();
		}

		private void EditButtonClick(object sender, RoutedEventArgs e)
		{
			int selectedId = ((Encouragement)dataGrid.SelectedItems[0]).Id;
			new EditEncouragementWindow(_db, selectedId).Show();
		}
	}
}

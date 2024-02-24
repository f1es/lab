using DataBaseInterface.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
	/// Логика взаимодействия для DirectorWindow.xaml
	/// </summary>
	public partial class DirectorWindow : Window
	{
		IS_Buro_KadrovContext _db;
		private int _editingId = -1;
		public DirectorWindow(IS_Buro_KadrovContext db)
		{
			InitializeComponent();
			_db = db;
		}

		public DirectorWindow(IS_Buro_KadrovContext db, int editingId)
		{
			InitializeComponent();
			_db = db;
			_editingId = editingId;

			Director director = _db.Directors.Where(enc => enc.Id == _editingId).Single();

			firstNameTextBox.Text = director.FirstName;
			lastNameTextBox.Text = director.LastName;
			middleTextBox.Text = director.MiddleNames;
			birthdayTextBox.Text = director.Birthday.ToString();
		}

		private void AcceptButtonClick(object sender, RoutedEventArgs e)
		{
			if (!DateTime.TryParse(birthdayTextBox.Text, out DateTime dateTime))
			{
				MessageBox.Show("Incorrect date");
				return;
			}

			if (_editingId != -1)
			{
				Director director = _db.Directors.Where(enc => enc.Id == _editingId).Single();

				director.FirstName = firstNameTextBox.Text;
				director.LastName = lastNameTextBox.Text;
				director.MiddleNames = middleTextBox.Text;
				director.Birthday = dateTime;
			}
			else
			{
				_db.Directors.Add(new Director() 
				{
					FirstName = firstNameTextBox.Text,
					LastName = lastNameTextBox.Text,
					MiddleNames = middleTextBox.Text,
					Birthday = dateTime
				});
			}
				
			_db.SaveChanges();

			foreach (Window window in Application.Current.Windows.OfType<MainWindow>())
			{
				((MainWindow)window).UpdateDataGrid();
			}
			Close();
		}

		private void CancelButtonClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}

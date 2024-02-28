using DataBaseInterface.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataBaseInterface.Windows
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

			if (_editingId == -1)
			{
				_db.Directors.Add(new Director()
				{
					FirstName = Regex.Replace(firstNameTextBox.Text, @"\s+", ""),
					LastName = Regex.Replace(lastNameTextBox.Text, @"\s+", ""),
					MiddleNames = Regex.Replace(middleTextBox.Text, @"\s+", ""),
					Birthday = dateTime
				});
			}
			else
			{
				Director director = _db.Directors.Where(enc => enc.Id == _editingId).Single();
				director.FirstName = Regex.Replace(firstNameTextBox.Text, @"\s+", "");
				director.LastName = Regex.Replace(lastNameTextBox.Text, @"\s+", ""); 
				director.MiddleNames = Regex.Replace(middleTextBox.Text, @"\s+", ""); 
				director.Birthday = dateTime;
			}
				
			_db.SaveChanges();
			((MainWindow)Application.Current.MainWindow).UpdateDataGrid();
			Close();
		}

		private void CancelButtonClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}

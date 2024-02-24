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
	/// Логика взаимодействия для CompanyWindow.xaml
	/// </summary>
	public partial class CompanyWindow : Window
	{
		private IS_Buro_KadrovContext _db;
		private int _editId = -1;
		public CompanyWindow(IS_Buro_KadrovContext db)
		{
			InitializeComponent();
			_db = db;

			//var directors = _db.Directors.Select(dir => dir.FirstName).ToList();
			directorComboBox.ItemsSource = GetFullNames();
		}

		public CompanyWindow(IS_Buro_KadrovContext db, int editId)
		{
			InitializeComponent();
			_db = db;
			_editId = editId;

			var directorsFirstNames = _db.Directors.Select(dir => dir.FirstName);

			directorComboBox.ItemsSource = GetFullNames();

			//var a = GetFullNames();

			Company company = _db.Companies.Where(dir => dir.Id == _editId).Single();
			companyNameTextBox.Text = company.CompanyName;
			baseDateTextBox.Text = company.BaseDate.ToString();
			//directorComboBox.SelectedItem = company.;
		}

		public List<string> GetFullNames()
		{
			var directorsFirstNames = _db.Directors.Select(dir => dir.FirstName).ToList();
			var directorsLastNames = _db.Directors.Select(dir => dir.LastName).ToList();
			var directorsMiddleNames = _db.Directors.Select(dir => dir.MiddleNames).ToList();
			List<string> fullNames = new List<string>();

			for (int i = 0; i < directorsFirstNames.Count(); i++)
			{
				fullNames.Add($"{directorsFirstNames[i]} {directorsMiddleNames[i]} {directorsLastNames[i]}");
			}

			return fullNames;
		}

		public string GetFullNameById(int id)
		{
			string fullName = "";

			var director = _db.Directors.Where(dir => dir.Id == id).Single();


			return fullName;
		}

		private void AcceptButtonClick(object sender, RoutedEventArgs e)
		{
			if (!DateTime.TryParse(baseDateTextBox.Text, out DateTime dateTime))
			{
				MessageBox.Show("Incorrect date");
				return;
			}
			int selectedDirectorId = _db.Directors.Where(dir => dir.FirstName == directorComboBox.Text).Single().Id;

			if (_editId != -1)
			{
				Company company = _db.Companies.Where(comp => comp.Id == _editId).Single();
				company.CompanyName = companyNameTextBox.Text;
				company.BaseDate = dateTime;
				company.DirectorId = selectedDirectorId;
			}
			else
			{
				Company company = new Company()
				{
					CompanyName = companyNameTextBox.Text,
					BaseDate = dateTime,
					DirectorId = selectedDirectorId
				};
				_db.Add(company);
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

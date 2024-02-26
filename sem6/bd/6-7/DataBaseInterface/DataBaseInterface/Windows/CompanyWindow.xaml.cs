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

namespace DataBaseInterface.Windows
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

			List<Director> directors = new List<Director>();
			foreach (var name in GetDirectorsFullNames())
            {
				directors.Add(_db.Directors.Where(dir => dir.Id == GetDirectorIdByFullName(name)).Single());
            }
			
			var unionDirecors = directors.Union(_db.Directors.ToList()).ToList();
			

			directorComboBox.ItemsSource = GetDirectorsFullNamesAsString();
		}

		public CompanyWindow(IS_Buro_KadrovContext db, int editId)
		{
			InitializeComponent();
			_db = db;
			_editId = editId;
			directorComboBox.ItemsSource = GetDirectorsFullNamesAsString();

			Company company = _db.Companies.Where(dir => dir.Id == _editId).Single();
			companyNameTextBox.Text = company.CompanyName;
			baseDateTextBox.Text = company.BaseDate.ToString();
			directorComboBox.SelectedItem = GetDirectorFullNameById(company.DirectorId).ToString();
		}

		public List<FullName> GetDirectorsFullNames()
		{
			return _db.Directors.Select(dir => dir.FullName).ToList();
		}
		public List<string> GetDirectorsFullNamesAsString()
		{
			List<string> fullNames = new List<string>();
			foreach (var name in GetDirectorsFullNames())
				fullNames.Add(name.ToString());
			directorComboBox.ItemsSource = fullNames;
			return fullNames;
		}
		public FullName GetDirectorFullNameById(int id)
		{
			var director = _db.Directors.Where(dir => dir.Id == id).Single();
			return director.FullName;
		}

		public int GetDirectorIdByFullName(FullName fullName)
		{
			int id;
			id = _db.Directors
				.Where(
				dir => dir.FirstName == fullName.FirstName &&
				dir.MiddleNames == fullName.MiddleName && 
				dir.LastName == fullName.LastName)
				.Single().Id;
			return id;
		}

		private void AcceptButtonClick(object sender, RoutedEventArgs e)
		{
			if (!DateTime.TryParse(baseDateTextBox.Text, out DateTime dateTime))
			{
				MessageBox.Show("Incorrect date");
				return;
			}
			int selectedDirectorId = GetDirectorIdByFullName(new FullName(directorComboBox.SelectedItem.ToString()));


			if (_editId == -1) //Add
			{
				Company company = new Company()
				{
					CompanyName = companyNameTextBox.Text,
					BaseDate = dateTime,
					DirectorId = selectedDirectorId
				};
				_db.Add(company);
			}
			else				//Edit
			{
				Company company = _db.Companies.Where(comp => comp.Id == _editId).Single();
				company.CompanyName = companyNameTextBox.Text;
				company.BaseDate = dateTime;
				company.DirectorId = selectedDirectorId;
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

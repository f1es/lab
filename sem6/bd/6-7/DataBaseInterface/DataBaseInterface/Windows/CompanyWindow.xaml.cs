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
		private DirectorsNames _directorsNames;
		public CompanyWindow(IS_Buro_KadrovContext db)
		{
			InitializeComponent();
			_db = db;
			_directorsNames = new DirectorsNames(_db);
			directorComboBox.ItemsSource = _directorsNames.GetExceptDirectorsNames();
		}

		public CompanyWindow(IS_Buro_KadrovContext db, int editId)
		{
			InitializeComponent();
			_db = db;
			_editId = editId;
            _directorsNames = new DirectorsNames(_db);

            Company company = _db.Companies.Where(dir => dir.Id == _editId).Single();
			companyNameTextBox.Text = company.CompanyName;
			baseDateTextBox.Text = company.BaseDate.ToString();
			string currentDirector = _directorsNames.GetDirectorFullNameById(company.DirectorId).ToString();

            List<FullName> directors = _directorsNames.GetExceptDirectorsNames();
			directors.Add(_directorsNames.GetDirectorFullNameById(company.DirectorId));

			directorComboBox.ItemsSource = directors;
            directorComboBox.SelectedValue = directors.Last();
		}

		private void AcceptButtonClick(object sender, RoutedEventArgs e)
		{
			if (!DateTime.TryParse(baseDateTextBox.Text, out DateTime dateTime))
			{
				MessageBox.Show("Incorrect date");
				return;
			}
			int selectedDirectorId = _directorsNames.GetDirectorIdByFullName(new FullName(directorComboBox.SelectedItem.ToString()));

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

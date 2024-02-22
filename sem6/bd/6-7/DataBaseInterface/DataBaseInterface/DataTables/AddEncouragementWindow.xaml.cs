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
	/// Логика взаимодействия для AddEncouragementWindow.xaml
	/// </summary>
	public partial class AddEncouragementWindow : Window
	{
		private IS_Buro_KadrovContext _db;
		public AddEncouragementWindow(IS_Buro_KadrovContext db)
		{
			InitializeComponent();
			_db = db;
		}

		private void AcceptButtonClick(object sender, RoutedEventArgs e)
		{
			_db.Encouragements.Add(new Encouragement() { EncouragementName = nameTextBox.Text });
			_db.SaveChanges();

			foreach(Window window in Application.Current.Windows.OfType<MainWindow>())
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

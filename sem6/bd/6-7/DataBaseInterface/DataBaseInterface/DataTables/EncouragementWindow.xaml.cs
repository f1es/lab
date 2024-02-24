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
    /// Логика взаимодействия для EditEncouragementWindow.xaml
    /// </summary>
    public partial class EncouragementWindow : Window
    {
        IS_Buro_KadrovContext _db;
        private int _editingId = -1;
        public EncouragementWindow(IS_Buro_KadrovContext db, int editId)
        {
            InitializeComponent();
            _db = db;
            _editingId = editId;
            Encouragement encouragement = _db.Encouragements.Where(enc  => enc.Id == _editingId).Single();
            nameTextBox.Text = encouragement.EncouragementName;
        }

		public EncouragementWindow(IS_Buro_KadrovContext db)
		{
			InitializeComponent();
			_db = db;
		}

		private void AcceptButtonClick(object sender, RoutedEventArgs e)
		{
            if (_editingId != -1)
            {
                _db.Encouragements.Where(enc => enc.Id == _editingId).Single().EncouragementName = nameTextBox.Text;
            }
            else
                _db.Encouragements.Add(new Encouragement() { EncouragementName = nameTextBox.Text});

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

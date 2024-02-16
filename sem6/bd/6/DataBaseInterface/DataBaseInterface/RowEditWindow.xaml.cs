using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataBaseInterface
{
    /// <summary>
    /// Логика взаимодействия для rowEditWindow.xaml
    /// </summary>
    public partial class RowEditWindow : Window
    {
        public ObservableCollection<EditField> EditFields { get; set; }
        private int _editingRow = -1;
		public RowEditWindow()
        {
            InitializeComponent();
        }

        public RowEditWindow(ObservableCollection<EditField> editFields, int editingRow)
        {
            InitializeComponent();
            EditFields = editFields;
            editListBox.ItemsSource = EditFields;
            _editingRow = editingRow;
		}

		private void acceptButton_Click(object sender, RoutedEventArgs e)
		{
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            object[] rowArray = mainWindow.TablesNamesDictionary[mainWindow.SelectedDataTableKey].Rows[_editingRow].ItemArray;

			for (int i = 0; i < rowArray.Length; i++)
			{
				rowArray[i] = EditFields[i].Content;
			}

            mainWindow.TablesNamesDictionary[mainWindow.SelectedDataTableKey].Rows[_editingRow].ItemArray = rowArray;
            Close();
		}

		private void cancelButton_Click(object sender, RoutedEventArgs e)
		{
            Close();
		}
	}
}

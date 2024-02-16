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
    /// Логика взаимодействия для RowAddWindow.xaml
    /// </summary>
    public partial class RowAddWindow : Window
    { 
		public RowAddWindow()
        {
            InitializeComponent();
        }
        
        public RowAddWindow(ObservableCollection<EditField> addFields)
        {
            InitializeComponent();
            addListBox.ItemsSource = addFields;
        }

		private void cancelButton_Click(object sender, RoutedEventArgs e)
		{
            Close();
		}

		private void acceptButton_Click(object sender, RoutedEventArgs e)
		{
            object[] newRow = new object[addListBox.Items.Count];
            for(int i = 0; i <  newRow.Length; i++)
            {
                newRow[i] = ((EditField)addListBox.Items[i]).Content;
            }

            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.TablesNamesDictionary[mainWindow.SelectedDataTableKey].Rows.Add(newRow);
            Close();
		}
	}
}

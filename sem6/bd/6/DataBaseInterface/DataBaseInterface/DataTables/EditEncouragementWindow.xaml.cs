﻿using DataBaseInterface.Entities;
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
    public partial class EditEncouragementWindow : Window
    {
        IS_Buro_KadrovContext _db;
        private int _id;
        public EditEncouragementWindow(IS_Buro_KadrovContext db, int editId)
        {
            InitializeComponent();
            _db = db;
            _id = editId;
            Encouragement encouragement = _db.Encouragements.Where(enc  => enc.Id == _id).Single();
            nameTextBox.Text = encouragement.EncouragementName;
        }

		private void AcceptButtonClick(object sender, RoutedEventArgs e)
		{
            //Encouragement encouragement = _db.Encouragements.Where(enc => enc.Id == _id).Single();
            //encouragement.EncouragementName = nameTextBox.Text;
            _db.Encouragements.Where(enc => enc.Id == _id).Single().EncouragementName = nameTextBox.Text;

            _db.SaveChanges();

			foreach (Window window in Application.Current.Windows.OfType<EncouragementWindow>())
			{
				((EncouragementWindow)window).UpdateDataGrid();
			}
			Close();
		}

		private void CancelButtonClick(object sender, RoutedEventArgs e)
		{
            Close();
		}
	}
}

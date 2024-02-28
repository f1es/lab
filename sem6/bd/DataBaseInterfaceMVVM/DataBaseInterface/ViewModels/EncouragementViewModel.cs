using DataBaseInterface.Entities;
using DataBaseInterface.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;


namespace DataBaseInterface.ViewModels
{
    public class EncouragementViewModel : ViewModelBase
    {
        private int _editingId = -1;
        private RelayCommand _acceptCommand;
        private RelayCommand _cancelCommand;
        private string _encName;
        public int EditingId 
        {
            get => _editingId;
            set => _editingId = value;
        }
        public RelayCommand AcceptCommand
        {
            get => _acceptCommand;
            private set
            {
                _acceptCommand = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand CancelCommand
        {
            get => _cancelCommand;
            private set
            {
                _cancelCommand = value;
                OnPropertyChanged();
            }
        }
        public string EncouragementName
        {
            get => _encName;
            set
            {
                _encName = value;
                OnPropertyChanged();
            }
        }
        public EncouragementViewModel(int editingId = -1)
        {
            _editingId = editingId;
            if (_editingId == -1)
                AcceptCommand = new RelayCommand(o =>
                {
                    _db.Encouragements.Add(new Encouragement() { EncouragementName = EncouragementName });
                    _db.SaveChanges();
                    ((ApplicationViewModel)Application.Current.MainWindow.DataContext).UpdateCurrentTable();
                    CloseWindow();

                    //((MainWindow)Application.Current.MainWindow).lb.Content = _editingId;
                });
            else
            {
                EncouragementName = _db.Encouragements.Where(enc => enc.Id == _editingId).Single().EncouragementName;

                AcceptCommand = new RelayCommand(o =>
                {
                    _db.Encouragements.Where(enc => enc.Id == _editingId).Single().EncouragementName = EncouragementName;
                    _db.SaveChanges();
                    ((ApplicationViewModel)Application.Current.MainWindow.DataContext).UpdateCurrentTable();
                    CloseWindow();

                    //((MainWindow)Application.Current.MainWindow).lb.Content = _editingId;
                });
            }
                
            CancelCommand = new RelayCommand(c => { CloseWindow(); });
        }
    }
}

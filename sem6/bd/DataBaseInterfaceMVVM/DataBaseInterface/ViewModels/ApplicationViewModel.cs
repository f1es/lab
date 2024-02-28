using DataBaseInterface.Entities;
using DataBaseInterface.Models;
using DataBaseInterface.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataBaseInterface.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private IS_Buro_KadrovContext _db = IS_Buro_KadrovContext.GetInstance();

        private ObservableCollection<string> _tablesNames = new ObservableCollection<string>();
        private string _currentTableName = string.Empty;
        private IEnumerable<IDBEntity> _currentTable;
        private IDBEntity _selectedItem;
        private int _selectedItemId = -1;

        private Page _currentPage = new Page();
        private TestFilterPage _filterPage = new TestFilterPage();

        private RelayCommand _addCommand;
        private RelayCommand _removeCommand;
        private RelayCommand _editCommand;

        public ObservableCollection<string> TablesNames
        {
            get => _tablesNames;
            private set => _tablesNames = value;    
        }
        public Page Page 
        { 
            get => _currentPage;
            set 
            {
                _currentPage = value;
                OnPropertyChanged();
            } 
        }
        public IDBEntity SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;

                if (_selectedItem != null)
                    SelectedItemId = SelectedItem.Id;
                else
                    SelectedItemId = -1;
                OnPropertyChanged();
            }
        }
        public int SelectedItemId
        {
            get => _selectedItemId;
            set
            {
                _selectedItemId= value;
                OnPropertyChanged();
            }
                
        }
        public string? CurrentTableName 
        {
            get => _currentTableName;
            set
            {
                _currentTableName = value;
                OnPropertyChanged();
                UpdateCurrentTable();
            } 
        }
        public IEnumerable<IDBEntity> CurrentTable
        {
            get => _currentTable;
            set
            {
                _currentTable = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand AddCommand 
        {
            get => _addCommand;
            set
            {
                _addCommand = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand RemoveCommand
        {
            get => _removeCommand;
            set
            {
                _removeCommand = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand EditCommand
        {
            get => _editCommand;
            set
            {
                _editCommand = value;
                OnPropertyChanged();
            }
        }
        public ApplicationViewModel()
        {
            _tablesNames.Add("Encouragements");
            _tablesNames.Add("Speciality");
            _tablesNames.Add("Department");
            _tablesNames.Add("Directors");
            _tablesNames.Add("Company");
            CurrentTable = _db.Encouragements.ToList();
        }
        public void UpdateCurrentTable()
        {
            AddCommand = null;
            RemoveCommand = null;
            EditCommand = null;

            switch (_currentTableName)
            {
                case "Encouragements":
                    CurrentTable = _db.Encouragements.ToList();
                    AddCommand = new RelayCommand(c => 
                    {
                        EncouragementViewModel encViewModel = new EncouragementViewModel();
                        new EncouragementWindow(encViewModel).Show(); 
                    });
                    EditCommand = new RelayCommand(c => 
                    {
                        if (SelectedItemId == -1)
                            return;
                        EncouragementViewModel encViewModel = new EncouragementViewModel(SelectedItemId);
                        new EncouragementWindow(encViewModel).Show(); 
                    });
                    RemoveCommand = new RelayCommand(c =>
                    {
                        var removingEntity = _db.Encouragements.Where(ent => ent.Id == SelectedItemId).Single();
                        _db.Encouragements.Remove(removingEntity);
                        _db.SaveChanges();
                        UpdateCurrentTable();
                    });
                    break;
                case "Directors":
                    CurrentTable = _db.Directors.ToList();
                    AddCommand = new RelayCommand(c => { new DirectorWindow(_db).Show(); });
                    break;
                case "Speciality":
                    CurrentTable = _db.Specialities.ToList();
                    //AddCommand = new RelayCommand()
                    break;
                case "Department":
                    CurrentTable = _db.Departments.ToList();
                    break;
                case "Company":
                    CurrentTable = _db.Companies.ToList();
                    AddCommand = new RelayCommand(c => { new CompanyWindow(_db).Show(); });
                    break;
            }
        }
        private void CloseWindow(Window window)
        {
            if (window != null)
                window.Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

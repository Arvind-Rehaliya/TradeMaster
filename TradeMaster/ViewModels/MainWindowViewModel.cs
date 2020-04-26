using System;
using System.Collections.Generic;
using System.Windows;
using TradeMaster.Commands;
using TradeMaster.Data;
using TradeMaster.IO.Tables;
using TradeMaster.Models;
using TradeMaster.Views;

namespace TradeMaster.ViewModels {
    public class MainWindowViewModel {
        public MainWindow View = null;

        private RelayCommand _addCommand = null;
        public RelayCommand AddCommand {
            get {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(AddExecute, CanAddExecute);
                return _addCommand;
            }
        }

        private RelayCommand _deleteCommand = null;
        public RelayCommand DeleteCommand {
            get {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(DeleteExecute, CanDeleteExecute);
                return _deleteCommand;
            }
        }

        private RelayCommand _updateCommand = null;
        public RelayCommand UpdateCommand {
            get {
                if (_updateCommand == null)
                    _updateCommand = new RelayCommand(UpdateExecute, CanUpdateExecute);
                return _updateCommand;
            }
        }

        private RelayCommand _refreshCommand = null;
        public RelayCommand RefreshCommand {
            get {
                if (_refreshCommand == null)
                    _refreshCommand = new RelayCommand(RefreshExecute, CanRefreshExecute);
                return _refreshCommand;
            }
        }

        private RelayCommand _minimizeCommand = null;
        public RelayCommand MinimizeCommand {
            get {
                if (_minimizeCommand == null)
                    _minimizeCommand = new RelayCommand(MinimizeCommandExecute, CanMinimizeCommandExecute);
                return _minimizeCommand;
            }
        }

        private RelayCommand _maximizeCommand = null;
        public RelayCommand MaximizeCommand {
            get {
                if (_maximizeCommand == null)
                    _maximizeCommand = new RelayCommand(MaximizeCommandExecute, CanMaximizeCommandExecute);
                return _maximizeCommand;
            }
        }

        private RelayCommand _closeCommand = null;
        public RelayCommand CloseCommand {
            get {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(CloseCommandExecute, CanCloseCommandExecute);
                return _closeCommand;
            }
        }

        private RelayCommand _searchCommand = null;
        public RelayCommand SearchCommand {
            get {
                if (_searchCommand == null)
                    _searchCommand = new RelayCommand(SearchCommandExecute, CanSearchCommandExecute);
                return _searchCommand;
            }
        }

        private RelayCommand _tableButtonCommand = null;
        public RelayCommand TableButtonCommand {
            get {
                if (_tableButtonCommand == null)
                    _tableButtonCommand = new RelayCommand(TableButtonCommandExecute, CanTableButtonCommandExecute);
                return _tableButtonCommand;
            }
        }


        private void AddExecute(object parameter) {
            MessageBox.Show($"Add Clicked {parameter}");
            new AddRowDetailsDialog().Visibility = Visibility.Visible;
        }

        private bool CanAddExecute(object parameter) {
            return true;
        }

        private void DeleteExecute(object parameter) {
            MessageBox.Show($"Delete Clicked {parameter}");

        }

        private bool CanDeleteExecute(object parameter) {
            return true;
        }

        private void UpdateExecute(object parameter) {
            MessageBox.Show($"Update Clicked {parameter}");

        }

        private bool CanUpdateExecute(object parameter) {
            return true;
        }

        private void RefreshExecute(object parameter) {
            MessageBox.Show($"Refresh Clicked {parameter}");
        }

        private bool CanRefreshExecute(object parameter) {
            return true;
        }

        private void MinimizeCommandExecute(object parameter) {
            View.WindowState = WindowState.Minimized;
        }

        private bool CanMinimizeCommandExecute(object parameter) {
            return true;
        }

        private void MaximizeCommandExecute(object parameter) {
            if (View.WindowState == WindowState.Normal)
                View.WindowState = WindowState.Maximized;
            else
                View.WindowState = WindowState.Normal;
        }

        private bool CanMaximizeCommandExecute(object parameter) {
            return true;
        }

        private void CloseCommandExecute(object parameter) {
            Application.Current.Shutdown();
        }

        private bool CanCloseCommandExecute(object parameter) {
            return true;
        }

        private void SearchCommandExecute(object parameter) {
            MessageBox.Show(parameter.ToString());
        }

        private bool CanSearchCommandExecute(object parameter) {
            return true;
        }

        private void TableButtonCommandExecute(object parameter) {
            try {
                List<TableDetails> tableDetails = new List<TableDetails>();
                tableDetails = XmlTablesNameList.Read();
                string tableName = string.Empty;

                for (int i = 0; i < tableDetails.Count; i++) {
                    if (tableDetails[i].TableButtonName.Equals(parameter.ToString())) {
                        tableName = tableDetails[i].TableName; break;
                    }
                }

                Database database = new Database();
                database.CreateConnection("employee", "localhost", "root", "3306", "");

                View.GetTable().ItemsSource = database.Reload(tableName).DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

        }

        private bool CanTableButtonCommandExecute(object parameter) {
            return true;
        }

    }
}

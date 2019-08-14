using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.View;
using MainWindow = WpfApp1.View.MainWindow;

namespace WpfApp1.ViewModel
{
    class UserViewModel
    {

        private IList<User> _UsersList;
        public ICommand CmdStartExecution { get; set; }
        public UserViewModel()
        {
            CmdStartExecution = new RelayCommand(p => NavigateToHome());
            _UsersList = new List<User>
            {
                new User{UserId = 1,FirstName="Raj",LastName="Beniwal",City="Delhi",State="DEL",Country="INDIA"},
                new User{UserId=2,FirstName="Mark",LastName="henry",City="New York", State="NY", Country="USA"},
                new User{UserId=3,FirstName="Mahesh",LastName="Chand",City="Philadelphia", State="PHL", Country="USA"},
                new User{UserId=4,FirstName="Vikash",LastName="Nanda",City="Noida", State="UP", Country="INDIA"},
                new User{UserId=5,FirstName="Harsh",LastName="Kumar",City="Ghaziabad", State="UP", Country="INDIA"},
                new User{UserId=6,FirstName="Reetesh",LastName="Tomar",City="Mumbai", State="MP", Country="INDIA"},
                new User{UserId=7,FirstName="Deven",LastName="Verma",City="Palwal", State="HP", Country="INDIA"},
                new User{UserId=8,FirstName="Ravi",LastName="Taneja",City="Delhi", State="DEL", Country="INDIA"}
            };
        } 

        public IList<User> Users
        {
            get { return _UsersList; }
            set { _UsersList = value; }
        }
        public void NavigateToHome()
        {
            MainWindow.MainWindowInstance.NavigationService.Navigate(new NewPage());
        }
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        public class RelayCommand : ICommand
        {
            private Predicate<object> _canExecute;
            private Action<object> _execute;

            public RelayCommand(Action<object> execute) : this(null, execute) { }

            public RelayCommand(Predicate<object> canExecute, Action<object> execute)
            {
                this._canExecute = canExecute;
                this._execute = execute;
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null ? true : _canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Page
    {
        public UserView()
        {
            InitializeComponent();
            UserViewModel VM = new UserViewModel(); // binding viewmodel với xaml 
            this.DataContext = VM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ExpenseItHome());
        }

        //private RelayCommand _commandStart;

        //public ICommand CmdStartExecution
        //{
        //    get
        //    {
        //        if (_commandStart == null)
        //        {
        //            _commandStart = new RelayCommand(param => Start(), param => CanStart());
        //        }
        //        return _commandStart;
        //    }
        //}

        //public bool Start()
        //{
        //    //Do what ever
        //    return true;
        //}

        //public bool CanStart()
        //{
        //    return (DateTime.Now.DayOfWeek == DayOfWeek.Monday); //Can only click that button on mondays.
        //}
    }
  
}

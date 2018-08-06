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
using ContactApplication.Application.ViewModels;

namespace ContactApplication.Application.Views
{
    /// <summary>
    /// Interaction logic for AddContactPage.xaml
    /// </summary>
    public partial class AddContactPage : Page
    {
        public AddContactPage(Navigation.NavigationController _navigationController)
        {
            DataContext = new AddContactPageViewModel(_navigationController);
            InitializeComponent();
        }
    }
}

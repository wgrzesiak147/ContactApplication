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
using ContactApplication.Application.Navigation;
using ContactApplication.Application.ViewModels;

namespace ContactApplication.Application.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(NavigationController navigationController)
        {
            DataContext = new MainPageViewModel(navigationController);
            InitializeComponent();
        }
    }
}

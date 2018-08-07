using System.Reflection;
using System.Windows;
using ContactApplication.Application.ViewModels;
using Ninject;

namespace ContactApplication.Application
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var viewModel = kernel.Get<IMainWindowViewModel>();
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
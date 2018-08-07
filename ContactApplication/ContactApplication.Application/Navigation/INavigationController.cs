using System.Windows.Controls;

namespace ContactApplication.Application.Navigation
{
    public interface INavigationController
    {
        Page CurrentPage { get; set; }
    }
}
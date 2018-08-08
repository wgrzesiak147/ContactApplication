using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApplication.Application.ViewModels;

namespace ContactApplication.Application.Views
{
    public interface IMainPage
    {
        IMainPageViewModel ViewModel { get; set; }
    }
}

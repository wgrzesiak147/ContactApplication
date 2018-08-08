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
using ContactApplication.Application.ViewModels.ContactPages;

namespace ContactApplication.Application.Views
{
    /// <summary>
    /// Interaction logic for AddContactPage.xaml
    /// </summary>
    public partial class AddContactPage : Page, IAddContactPage
    {
        public AddContactPage()
        {
            InitializeComponent();
        }

        private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var s = sender as TextBox;
            // Use SelectionStart property to find the caret position.
            // Insert the previewed text into the existing text in the textbox.
            var text = s.Text.Insert(s.SelectionStart, e.Text);

            double d;
            // If parsing is successful, set Handled to false
            e.Handled = !double.TryParse(text, out d);
        }
    }
}

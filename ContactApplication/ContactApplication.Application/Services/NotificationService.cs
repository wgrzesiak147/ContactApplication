using System.Windows;

namespace ContactApplication.Application.Services
{
    public class NotificationService : INotificationService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}

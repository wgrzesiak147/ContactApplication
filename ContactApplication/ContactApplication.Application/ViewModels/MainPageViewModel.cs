using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using ContactApplication.Application.Mappers;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.ViewModels.ContactPages;
using ContactApplication.Application.Views;
using ContactApplication.Remote.Interfaces;
using ContactApplication.Remote.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ContactApplication.Application.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _searchQuery;

        public MainPageViewModel(NavigationController navigationController)
        {
            ContactService = new ContactService(new HttpJsonClientFactory());
            NavigationController = navigationController;
            AddContactCommand = new RelayCommand(AddContact);
            RemoveContactCommand = new RelayCommand(RemoveContact);
            LoadContactsCommand = new RelayCommand(LoadContacts);
            EditContactCommand = new RelayCommand(EditContact);
            Contacts = new ObservableCollection<ContactModel>();
            LoadContacts();
        }

        public ObservableCollection<ContactModel> Contacts { get; set; }

        public ICollectionView FilteredContacts
        {
            get
            {
                var source = CollectionViewSource.GetDefaultView(Contacts);
                source.Filter = p => Filter((ContactModel) p);
                return source;
            }
        }

        private NavigationController NavigationController { get; }

        private IContactService ContactService { get; set; }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                FilteredContacts.Refresh();
            }
        }

        public ContactModel SelectedContact { get; set; }

        public ICommand LoadContactsCommand { get; set; }

        public ICommand RemoveContactCommand { get; set; }

        public ICommand AddContactCommand { get; set; }

        public ICommand EditContactCommand { get; set; }

        public bool Filter(ContactModel model)
        {
            if (string.IsNullOrEmpty(SearchQuery)) return true;
            return model.FirstName.ToLower().StartsWith(SearchQuery.ToLower());
        }

        private void EditContact()
        {
            NavigationController.CurrentPage =
                new AddContactPage(new EditContactPageViewModel(NavigationController, SelectedContact));
        }

        private void RemoveContact()
        {
            if (SelectedContact == null)
            {
                MessageBox.Show("Select Contact to remove");
                return;
            }
            ContactService.RemoveAsync(ContactModelMapper.Map(SelectedContact));

            LoadContacts();
        }

        private async void LoadContacts()
        {
            Contacts.Clear();

            var contacts = await ContactService.ReadAsync();
            foreach (var contact in contacts)
                Contacts.Add(ContactModelMapper.Map(contact));

            FilteredContacts.Refresh();
        }

        public void AddContact()
        {
            NavigationController.CurrentPage = new AddContactPage(new AddContactPageViewModel(NavigationController));
        }
    }
}
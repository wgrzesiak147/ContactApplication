using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using ContactApplication.Application.Mappers;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Services;
using ContactApplication.Application.ViewModels.ContactPages;
using ContactApplication.Application.Views;
using ContactApplication.Remote.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ContactApplication.Application.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IMainPageViewModel
    {
        private string _searchQuery;

        public MainPageViewModel(INavigationController navigationController, INotificationService notificationService,
            IContactService contactService,
            IAddContactPage addContactPage)
        {
            NotificationService = notificationService;
            ContactService = contactService;
            NavigationController = navigationController;
            AddContactPage = addContactPage;
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

        private INavigationController NavigationController { get; }

        private IContactService ContactService { get; }

        private INotificationService NotificationService { get; }

        public IAddContactPage AddContactPage { get; set; }

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

        public IMainPage MainPage { get; set; }

        public async void LoadContacts()
        {
            Contacts.Clear();

            try
            {
                var contacts = await ContactService.ReadAsync();
                foreach (var contact in contacts)
                    Contacts.Add(ContactModelMapper.Map(contact));
            }
            catch (Exception)
            {
                NotificationService.ShowMessage("error during connecting to web api, try again");
            }

            FilteredContacts.Refresh();
        }

        public bool Filter(ContactModel model)
        {
            if (string.IsNullOrEmpty(SearchQuery)) return true;
            return model.FirstName.ToLower().StartsWith(SearchQuery.ToLower());
        }

        private void EditContact()
        {
            var addContactPage = (Page) AddContactPage;
            addContactPage.DataContext =
                new EditContactPageViewModel(MainPage, NavigationController, ContactService, NotificationService,
                    SelectedContact);
            NavigationController.CurrentPage = addContactPage;
        }

        private async void RemoveContact()
        {
            if (SelectedContact == null)
            {
                NotificationService.ShowMessage("Select contact to remove");
                return;
            }
            await ContactService.RemoveAsync(ContactModelMapper.Map(SelectedContact));

            LoadContacts();
        }

        public void AddContact()
        {
            var addContactPage = (Page) AddContactPage;
            addContactPage.DataContext =
                new AddContactPageViewModel(MainPage, NavigationController, ContactService, NotificationService);
            NavigationController.CurrentPage = addContactPage;
        }
    }
}
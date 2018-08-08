﻿using System.Windows.Controls;
using ContactApplication.Application.Mappers;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Services;
using ContactApplication.Application.Views;
using ContactApplication.Remote.Interfaces;

namespace ContactApplication.Application.ViewModels.ContactPages
{
    public class AddContactPageViewModel : ContactPageViewModelBase, IAddContactPageViewModel
    {
        public AddContactPageViewModel(IMainPage mainPage, INavigationController navigationController,
            IContactService contactService, INotificationService notificationService) : base(mainPage,
            navigationController, contactService, notificationService)
        {
        }

        public override async void Save()
        {
            if (string.IsNullOrEmpty(Contact.FirstName) || string.IsNullOrEmpty(Contact.FirstName))
            {
                NotificationService.ShowMessage("Fill First Name and Last Name");
                return;
            }
            await ContactService.AddAsync(ContactModelMapper.Map(Contact));
            NavigationController.CurrentPage = (Page) MainPage;
            MainPage.ViewModel.LoadContacts();
        }
    }
}
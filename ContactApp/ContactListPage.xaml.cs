using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ContactApp
{
    public partial class ContactListPage : ContentPage
    {
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

        public ContactListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ContactListView.ItemsSource = contacts;
        }

        async void OnAddClicked(object sender, EventArgs eventArgs)
        {
            var entryDetailsPage = new ContactEntryDetailsPage();
            entryDetailsPage.BindingContext = new Contact();

            entryDetailsPage.OnContactAdded += (s, e) =>
              {
                  contacts.Add(entryDetailsPage.BindingContext as Contact);
              };

            await Navigation.PushAsync(entryDetailsPage);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs eventArgs)
        {
            var entryDetailsPage = new ContactEntryDetailsPage();
            entryDetailsPage.BindingContext = eventArgs.SelectedItem as Contact;

            await Navigation.PushAsync(entryDetailsPage);
        }
    }
}

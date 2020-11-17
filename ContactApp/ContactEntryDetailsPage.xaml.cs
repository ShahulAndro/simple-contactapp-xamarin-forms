using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ContactApp
{
    public partial class ContactEntryDetailsPage : ContentPage
    {
        public EventHandler OnContactAdded;
        public ContactEntryDetailsPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs eventArgs)
        {
            OnContactAdded.Invoke(this, null);
            await Navigation.PopAsync();
        }
    }
}

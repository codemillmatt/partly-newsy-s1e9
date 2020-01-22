using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Auth;
using Xamarin.Forms;


namespace PartlyNewsy.Core
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected async void HandleLogin_Tapped(object sender, EventArgs e)
        {
            var authService = new AuthenticationService();

            if (authService.IsLoggedIn())
            {
                var success = await authService.Login();

                string message = "";
                if (success)
                {
                    message = (authService.IsLoggedIn()).ToString();
                }
                else
                    message = "oh oh";

                await DisplayAlert("Login Results", message, "ok");
            }
            else
            {
                authService.Logout();
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AppCenter.Auth;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PartlyNewsy.Core
{
    public class AuthenticationService
    {
        const string HasLoggedIn = "hasloggedin";

        public bool IsLoggedIn()
        {
            var loggedIn = Preferences.Get(HasLoggedIn, false);

            return loggedIn;
        }
        
        public async Task<bool> Login()
        {
            try
            {                
                var user = await Auth.SignInAsync();

                Preferences.Set(HasLoggedIn, true);                                              
            }
            catch (Exception ex)
            {
                Preferences.Set(HasLoggedIn, false);

                System.Diagnostics.Debug.WriteLine(ex);

                return false;
            }

            return true;
        }

        public bool Logout()
        {
            try
            {
                Auth.SignOut();
                Preferences.Set(HasLoggedIn, false);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

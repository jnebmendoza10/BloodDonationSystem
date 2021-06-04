using BloodDonationApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodDonationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (NetworkStatus.IsConnected())
            {
                int result = await ApiServices.LoginDonor(EntEmail.Text, EntPassword.Text);
                if(result > 0)
                {
                     Application.Current.MainPage = new HomePage(result);
                }
                else if (result == -69)
                {
                    await DisplayAlert("Failed", "Invalid username or password", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Warning", "There is no internet connection", "Cancel");
            }
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("Notice", "Before proceeding, do you have any past illnesses", "Yes", "No");
            if (!action)
            {
                await Navigation.PushAsync(new RegisterPage());
            }
            else
            {
                await DisplayAlert("Notice", "Sorry you are not allowed to proceed", "Ok");
            }
        }
    }
}
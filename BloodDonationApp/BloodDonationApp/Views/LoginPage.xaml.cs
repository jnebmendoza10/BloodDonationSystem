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
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void BtnSubmitDonor_Clicked(object sender, EventArgs e)
        {
            if (NetworkStatus.IsConnected())
            {
                if (!txtPassword.Text.Equals(txtConfirm.Text))
                {
                    await DisplayAlert("Warning", "Passwords mismatch", "Ok");
                }
                else
                {
                    var response = await ApiServices.RegisterDonor(txtFirstNameDonor.Text, txtLastNameDonor.Text, DatePicker_Donor.Date, txtAddressDonor.Text, txtContactDonor.Text, BloodTypes.SelectedItem.ToString(), txtEmail.Text, txtPassword.Text);
                    if (response == 1)
                    {
                        await DisplayAlert("Success", "Your account has been created", "Ok");
                    }
                    else if (response == -69)
                    {
                        await DisplayAlert("Failed", "Email already exists", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Failed", "Registration Failed", "Ok");
                    }
                }
            }
            else
            {
                await DisplayAlert("Warning", "There is no internet connection", "Cancel");
            }
        }
    }
}
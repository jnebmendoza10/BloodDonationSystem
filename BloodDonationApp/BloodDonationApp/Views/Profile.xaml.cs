using BloodDonationApp.Models;
using BloodDonationApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodDonationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        string donorId = Preferences.Get("donorId", string.Empty);
      
        public Profile()
        {
            InitializeComponent();
            GetDonorById(int.Parse(donorId));
            
        }
       
        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (NetworkStatus.IsConnected())
            {
                if (!txtPassword.Text.Equals(txtConfirm.Text))
                {
                    await DisplayAlert("Warning", "Passwords mismatch", "Ok");
                }
                else
                {
                    var response = await ApiServices.UpdateProfile(int.Parse(donorId), txtFirstNameDonor.Text, txtLastNameDonor.Text, DatePicker_Donor.Date, txtAddressDonor.Text, txtContactDonor.Text, BloodTypes.SelectedItem.ToString(), txtEmail.Text, txtPassword.Text);
                    if (response)
                    {
                        await DisplayAlert("Success", "Your account has been updated", "Ok");
                    }
                    else 
                    {
                        await DisplayAlert("Failed", "Cannot update account", "Ok");
                    }
                    
                }
            }
            else
            {
                await DisplayAlert("Warning", "There is no internet connection", "Cancel");
            }
            
        }

        private async void BtnSignOut_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("Notice", "Do you want to sign out?", "Yes", "No");
            if (action)
            {
                Application.Current.MainPage = new LoginPage();
            }
            
        }

        public async void GetDonorById(int id)
        {
            var donor = await ApiServices.GetDonorCredentials(id);
            txtFirstNameDonor.Text = donor.FirstName;
            txtLastNameDonor.Text = donor.LastName;
            DatePicker_Donor.Date = donor.DateOfBirth;
            txtAddressDonor.Text = donor.Address;
            txtContactDonor.Text = donor.ContactNumber;
            BloodTypes.SelectedItem = donor.BloodGroup;
            txtEmail.Text = donor.Email;
            txtPassword.Text = donor.Password;
            txtConfirm.Text = donor.Password;
        }
        
    }
}
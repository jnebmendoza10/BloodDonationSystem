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
       
        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {

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
        }
        
    }
}
using BloodDonationApp.Models;
using BloodDonationApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodDonationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateDeleteAppointmentPage : ContentPage
    {
        private ObservableCollection<string> LocationCollection;
        int appointmentId;
        string donorId = Preferences.Get("donorId", string.Empty);

        public UpdateDeleteAppointmentPage(int result, DateTime appointment, string location)
        {
            InitializeComponent();
            LocationCollection = new ObservableCollection<string>();
            appointmentId = result;
            DatePicker_DonorDonation.Date = appointment;
            GetLocations();
            Locations.SelectedItem = location;


        }

        private async void BtnSubmitEditedAppointment_Clicked(object sender, EventArgs e)
        {
            var response = await ApiServices.PutAppointmentAsync(appointmentId, int.Parse(donorId), DatePicker_DonorDonation.Date,Locations.SelectedItem.ToString());

            if (response)
            {
                await DisplayAlert("Success", "Update is successful", "Ok");
            }
            else 
            {
                await DisplayAlert("Failed", "Update Failed", "Ok");
            }
            //else if (response == -100)
           // {
                //await DisplayAlert("Failed", "Connection Error", "Ok");
            //}
        }

        private async void BtnDeleteAppointment_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("Notice", "Before proceeding, do you want to delete this appointment?", "Yes", "No");
            if (action)
            {
                var response = await ApiServices.DeleteAppointmentAsync(appointmentId);
                if (response)
                {
                    await DisplayAlert("Success", "Appointment cancellation success", "Ok");
                    Application.Current.MainPage = new HomePage();
                }
                else
                {
                    await DisplayAlert("Failed", "Failed to cancel appointment", "Ok");
                }
                
            }
            
        }
        public async void GetLocations()
        {
            var locations = await ApiServices.GetLocations();
            foreach (var location in locations)
            {
                LocationCollection.Add(location.BloodBankName);
            }
            Locations.ItemsSource = LocationCollection;

        }

        private void BtnCancelAppointment_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HomePage();
        }
    }
}
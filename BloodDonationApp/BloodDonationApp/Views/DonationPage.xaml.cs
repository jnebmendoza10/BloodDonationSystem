using BloodDonationApp.Models;
using BloodDonationApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BloodDonationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DonationPage : ContentPage
    {
        
        
        private int userId;
        private ObservableCollection<string> LocationCollection;
        public DonationPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LocationCollection = new ObservableCollection<string>();
            GetLocations();

        }

        private async void BtnSubmitAppointment_Clicked(object sender, EventArgs e)
        {
            AppointmentModel appointment = new AppointmentModel()
            {
                DonorId = userId,
                Location = Locations.SelectedItem.ToString(),
                AppointmentDate = DatePicker_DonorDonation.Date

            };

            var response = await ApiServices.AddAppointment(userId, Locations.SelectedItem.ToString(), DatePicker_DonorDonation.Date + TimePicker_Donation.Time);

            if (response)
            {
                await DisplayAlert("Success", "Your appointment has been set", "Ok");
               
            }
            else
            {
                await DisplayAlert("Error", "Please try again", "Ok");
            }
           
            
        }

        private void BtnCancelAppointment_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HomePage();
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
    }
}
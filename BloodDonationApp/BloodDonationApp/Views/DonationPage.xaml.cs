using BloodDonationApp.Models;
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
        public DonationPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private async void BtnSubmitAppointment_Clicked(object sender, EventArgs e)
        {
            AppointmentModel appointment = new AppointmentModel()
            {
                DonorId = userId,
                LocationId = 1,
                AppointmentDate = DatePicker_DonorDonation.Date

            };
           
            
        }

        private void BtnCancelAppointment_Clicked(object sender, EventArgs e)
        {

        }
    }
}
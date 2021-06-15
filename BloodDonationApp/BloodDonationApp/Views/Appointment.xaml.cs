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
    public partial class Appointment : ContentPage
    {
        ObservableCollection<AppointmentModel> appointments;
        string donorId = Preferences.Get("donorId", string.Empty);
        
        public Appointment()
        {
            InitializeComponent();
            appointments = new ObservableCollection<AppointmentModel>();
            GetAppointments();
            this.BindingContext = this;
        }
        
       
       
        public async void GetAppointments()
        {
            var appointmentList = await ApiServices.GetAppointments();
            foreach (var appointment in appointmentList)
            {
                appointments.Add(new AppointmentModel { Location = appointment.Location, AppointmentDate = appointment.AppointmentDate.Date });
            }
            AppointmentListView.ItemsSource = appointments;
            

        }

        private void BtnAddAppointment_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new DonationPage(int.Parse(donorId));
        }
    }
}
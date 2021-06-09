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
    public partial class Appointment : ContentPage
    {
        ObservableCollection<AppointmentModel> appointments;
        private int userId;
        public Appointment()
        {
            InitializeComponent();
            appointments = new ObservableCollection<AppointmentModel>();
            GetAppointments();
        }
        public Appointment (int userId)
        {
            this.userId = userId;
        }
        public Appointment (AppointmentModel appointment)
        {
            AppointmentListView.ItemsSource = appointments;
        }
       
        public async void GetAppointments()
        {
            var appointmentList = await ApiServices.GetAppointments();
            foreach (var appointment in appointmentList)
            {
                appointments.Add(appointment);
            }
            AppointmentListView.ItemsSource = appointments;

        }

        private void BtnAddAppointment_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new DonationPage(this.userId);
        }
    }
}
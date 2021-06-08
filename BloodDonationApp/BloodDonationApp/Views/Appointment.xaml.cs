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
        public Appointment(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            appointments = new ObservableCollection<AppointmentModel>();
            GetAppointments();
        }

        public Appointment (AppointmentModel appointment)
        {
            AppointmentListView.ItemsSource = appointments;
        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DonationPage(userId));
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
    }
}
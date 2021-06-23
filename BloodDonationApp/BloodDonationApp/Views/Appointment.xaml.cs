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
        ViewCell lastCell;
        public Appointment()
        {
            InitializeComponent();
            appointments = new ObservableCollection<AppointmentModel>();
            GetAppointments();
            this.BindingContext = this;
        }
        
       
       
        public async void GetAppointments()
        {
            var appointmentList = await ApiServices.GetAppointments(int.Parse(donorId));
            foreach (var appointment in appointmentList)
            {
                appointments.Add(new AppointmentModel { Location = appointment.Location, AppointmentDate = appointment.AppointmentDate.Date, AppointmentId = appointment.AppointmentId});
            }
            AppointmentListView.ItemsSource = appointments;
            

        }

        private void BtnAddAppointment_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new DonationPage(int.Parse(donorId));
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.Red;
                lastCell = viewCell;
            }
        }

        private void AppointmentListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
            ListView listView = (ListView)sender;
            if (listView != null)
            {
                DateTime appointmentDate = (e.Item as AppointmentModel).AppointmentDate;
                string location = (e.Item as AppointmentModel).Location;
                int id = (e.Item as AppointmentModel).AppointmentId;
                //int result = await ApiServices.GetAppointmentId(appointmentDate);
                Application.Current.MainPage = new UpdateDeleteAppointmentPage(id, appointmentDate,location);
            }
            
        }
    }
}
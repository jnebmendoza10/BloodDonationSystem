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
    public partial class Appointment : ContentPage
    {
        ObservableCollection<AppointmentModel> appointments;
        private int userId;
        public Appointment(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        public Appointment (AppointmentModel appointment)
        {
            AppointmentListView.ItemsSource = appointments;
        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DonationPage(userId));
        }
    }
}
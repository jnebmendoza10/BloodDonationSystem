using System;
using System.Collections.Generic;
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
        public DonationPage()
        {
            InitializeComponent();
        }

        private void BtnSubmitAppointment_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnCancelAppointment_Clicked(object sender, EventArgs e)
        {

        }
    }
}
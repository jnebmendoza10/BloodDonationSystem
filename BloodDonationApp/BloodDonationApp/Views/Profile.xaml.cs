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
    public partial class Profile : ContentPage
    {
        private int userId;
        public Profile()
        {
            InitializeComponent();
            
            
        }
        public Profile (int userId)
        {
            this.userId = userId;
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

        
    }
}
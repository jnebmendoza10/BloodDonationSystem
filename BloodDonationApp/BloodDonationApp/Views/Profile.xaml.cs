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
        public Profile(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnSignOut_Clicked(object sender, EventArgs e)
        {

        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace BloodDonationApp
{
    public class NetworkStatus
    {
        public static bool IsConnected()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
                return true;
            else
                return false;
        }
    }
}

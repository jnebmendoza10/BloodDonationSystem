﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BloodDonationSystemWebAPI.Models
{
    public class ConnectionString
    {
        public static string  SqlConnetionString = ConfigurationManager.ConnectionStrings["BloodDonation"].ConnectionString;
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonationSystemWebAPI.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string BloodBankName { get; set; }
        public string LocationName { get; set; }
    }
}
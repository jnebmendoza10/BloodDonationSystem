using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonationSystemWebAPI.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DonorId { get; set; }
        public string Location { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
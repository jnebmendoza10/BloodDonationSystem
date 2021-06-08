using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonationApp.Models
{
    public class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public int DonorId { get; set; }
        public int LocationId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}

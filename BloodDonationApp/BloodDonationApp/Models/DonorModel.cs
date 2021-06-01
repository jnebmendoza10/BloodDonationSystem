using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonationApp.Models
{
    public class DonorModel
    {
        public int DonorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string BloodGroup { get; set; }


        public string Email { get; set; }
        public string Password { get; set; }
    }
}

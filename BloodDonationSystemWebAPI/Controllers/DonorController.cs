using BloodDonationSystemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace BloodDonationSystemWebAPI.Controllers
{
    public class DonorController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BloodDonation"].ConnectionString;
        public int Post([FromBody]DonorModel donor)
        {
            //try
            //{
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("spRegisterDonor", connection))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = donor.FirstName;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = donor.LastName;
                    cmd.Parameters.Add("@dateofbirth", SqlDbType.Date).Value = donor.DateOfBirth;
                    cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = donor.Address;
                    cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = donor.ContactNumber;
                    cmd.Parameters.Add("@bloodgroup", SqlDbType.VarChar).Value = donor.BloodGroup;

                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = donor.Email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = donor.Password;

                    connection.Open();

                    return (int)cmd.ExecuteNonQuery();


                }
                
            //}
            //catch
            //{
            //    return -1;
                
            //}
        }
    }
}

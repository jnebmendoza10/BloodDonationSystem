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
        
        [HttpPost]
        public int RegisterDonor([FromBody]DonorModel donor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.SqlConnetionString))
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

                    return (int)cmd.ExecuteScalar();


                }
                
            }
            catch
            {
               return -1;
                
            }
        }

        public int LoginDonor([FromBody] DonorModel donor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.SqlConnetionString))
                using (SqlCommand cmd = new SqlCommand("spLoginDonor", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                   

                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = donor.Email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = donor.Password;

                    connection.Open();

                    return (int)cmd.ExecuteScalar();

                }

            }
            catch
            {
                return -1;

            }
        }
        [HttpGet]
        public DonorModel GetDonorDetail(int id)
        {
            DonorModel donor = new DonorModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.SqlConnetionString))
                using (SqlCommand cmd = new SqlCommand("spGetDonorById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = id;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
          

                        donor.FirstName = reader["FirstName"].ToString();
                        donor.LastName = reader["LastName"].ToString();
                        donor.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                        donor.Address = reader["Address"].ToString();
                        donor.ContactNumber = reader["ContactNumber"].ToString();
                        donor.BloodGroup = reader["BloodGroup"].ToString();
                        donor.Email = reader["Email"].ToString();
                        donor.Password = reader["Password"].ToString();
                        
                    }

                }
                return donor;
            }
            catch
            {

                return null;
            }
        }
        [HttpPut]
        public int UpdateDonorProfile(int id, [FromBody] DonorModel donor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.SqlConnetionString))
                using (SqlCommand cmd = new SqlCommand("spUpdateDonorProfile", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = donor.FirstName;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = donor.LastName;
                    cmd.Parameters.Add("@dateofbirth", SqlDbType.Date).Value = donor.DateOfBirth;
                    cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = donor.Address;
                    cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = donor.ContactNumber;
                    cmd.Parameters.Add("@blood", SqlDbType.VarChar).Value = donor.BloodGroup;

                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = donor.Email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = donor.Password;

                    connection.Open();

                   

                    return (int)cmd.ExecuteNonQuery();


                }

            }
            catch
            {
                return -1;

            }
        }
    }
}

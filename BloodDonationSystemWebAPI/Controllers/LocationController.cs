using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using BloodDonationSystemWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace BloodDonationSystemWebAPI.Controllers
{
    public class LocationController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BloodDonation"].ConnectionString;

        public IEnumerable<Location> Get()
        {
            List<Location> locations = new List<Location>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("spGetLocations", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Location location = new Location();
                        //blood.BloodId = Convert.ToInt32(reader["BloodId"]);
                        //blood.BloodType = reader["BloodType"].ToString();
                        location.LocationId = Convert.ToInt32(reader["LocationId"]);
                        location.BloodBankName = reader["BloodBankName"].ToString();
                        location.LocationName = reader["LocationName"].ToString();

                        locations.Add(location);
                    }

                }
                return locations;
            }
            catch
            {

                return null;
            }
        }
    }
}

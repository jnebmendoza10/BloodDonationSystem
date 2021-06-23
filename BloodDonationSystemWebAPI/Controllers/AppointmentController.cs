using BloodDonationSystemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BloodDonationSystemWebAPI.Controllers
{
    public class AppointmentController : ApiController
    {
       
        [HttpGet]
        public IEnumerable<Appointment> GetAppointments(int id)
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.SqlConnetionString))
                using (SqlCommand cmd = new SqlCommand("spGetAppointments", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@donorid", SqlDbType.Int).Value = id;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();

                        appointment.AppointmentId = int.Parse(reader["AppointmentId"].ToString());
                        appointment.DonorId = int.Parse(reader["DonorId"].ToString());
                        appointment.Location = reader["BloodBankName"].ToString();
                        appointment.AppointmentDate = DateTime.Parse(reader["AppointmentDate"].ToString());


                        appointments.Add(appointment);
                    }

                }
                return appointments;
            }
            catch
            {

                return null;
            }
        }

        [HttpPost]
        public int SetAppointment([FromBody] Appointment appointment)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.SqlConnetionString))
                using (SqlCommand cmd = new SqlCommand("spSetAppointment", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    cmd.Parameters.Add("@donorid", SqlDbType.Int).Value = appointment.DonorId;
                    cmd.Parameters.Add("@bloodbank", SqlDbType.VarChar).Value = appointment.Location;
                    cmd.Parameters.Add("@appointmentdate", SqlDbType.Date).Value = appointment.AppointmentDate;

                    connection.Open();

                    return (int)cmd.ExecuteScalar();


                }

            }
            catch
            {
                return -1;

            }
        }

        [HttpPut]
        public int UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.SqlConnetionString))
                using (SqlCommand cmd = new SqlCommand("spUpdateAppointment", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@appointmentid", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@bloodbank", SqlDbType.VarChar).Value = appointment.Location;
                    cmd.Parameters.Add("@appointmentdate", SqlDbType.Date).Value = appointment.AppointmentDate;
                    

                    connection.Open();

                    return (int)cmd.ExecuteNonQuery();


                }

            }
            catch
            {
                return -1;

            }
        }

        [HttpDelete]
        public int DeleteAppointment(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.SqlConnetionString))
                using (SqlCommand cmd = new SqlCommand("spDeleteAppointment", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@appointmentid", SqlDbType.DateTime).Value = id;
                   

                    connection.Open();

                    return (int)cmd.ExecuteNonQuery();


                }

            }
            catch
            {
                return -1;

            }
        }

        [HttpGet]
        public int GetAppointmentId(DateTime appointment)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.SqlConnetionString))
                using (SqlCommand cmd = new SqlCommand("spGetAppointmentId", connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@appointmentdate", SqlDbType.DateTime).Value = appointment;


                    connection.Open();

                    return (int)cmd.ExecuteScalar();


                }

            }
            catch
            {
                return -1;

            }
        }
    }
}

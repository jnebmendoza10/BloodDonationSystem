using BloodDonationApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace BloodDonationApp.Services
{
    public class ApiServices
    {
        public static async Task<int> RegisterDonor(string firstname, string lastname, DateTime dateOfBirth, string address, string contactNumber, string bloodGroup, string email, string password)
        {
            var donor = new DonorModel()
            {
                FirstName = firstname,
                LastName = lastname,
                DateOfBirth = dateOfBirth,
                Address = address,
                ContactNumber = contactNumber,
                BloodGroup = bloodGroup,
                Email = email,
                Password = password
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(donor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(Constant.ApiUrl + "api/Donor/RegisterDonor", content);
            var resultJson = response.Content.ReadAsStringAsync().Result;
            var resultObject = JsonConvert.DeserializeObject(resultJson);
            
            if (response.IsSuccessStatusCode)
            {
                return int.Parse(resultObject.ToString());
            }
            else
            {
                return -100;
            }
        }

        public static async Task<bool> UpdateProfile(int userId, string firstname, string lastname, DateTime dateOfBirth, string address, string contactNumber, string bloodGroup, string email, string password)
        {
            var donor = new DonorModel()
            {
                FirstName = firstname,
                LastName = lastname,
                DateOfBirth = dateOfBirth,
                Address = address,
                ContactNumber = contactNumber,
                BloodGroup = bloodGroup,
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(donor);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await httpClient.PutAsync(Constant.ApiUrl + "Donor/UpdateDonorProfile/" + userId, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<int> LoginDonor(string email, string password)
        {
            var donor = new DonorModel()
            {
                Email = email,
                Password = password
            };

            var httpclient = new HttpClient();
            var json = JsonConvert.SerializeObject(donor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpclient.PostAsync(Constant.ApiUrl + "api/Donor/LoginDonor", content);
            var resultJson = response.Content.ReadAsStringAsync().Result;
            var resultObject = JsonConvert.DeserializeObject(resultJson);

            if (response.IsSuccessStatusCode)
            {
                return int.Parse(resultObject.ToString());
            }
            else
            {
                return -100;
            }
        }

        public static async Task<DonorModel> GetDonorCredentials (int userId)
        {
            var httpClient = new HttpClient();
            //var response = await httpClient.GetAsync(Constant.ApiUrl + "api/Donor/GetDonorDetail" + userId);

           
            var jsonData = await httpClient.GetStringAsync(Constant.ApiUrl + "api/Donor/GetDonorDetail/" + userId);
            var donor = JsonConvert.DeserializeObject<DonorModel>(jsonData);
         
                return donor;
            
           
        }

        public static async Task<List<AppointmentModel>> GetAppointments(int donorId)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(Constant.ApiUrl + "api/Appointment/GetAppointments/" + donorId);

            var appointments = JsonConvert.DeserializeObject<List<AppointmentModel>>(json);

            return appointments;
        }

        public static async Task<int> AddAppointment(int userId, string location, DateTime appointmentDate)
        {
            var appointment = new AppointmentModel()
            {
               DonorId = userId,
               Location = location,
               AppointmentDate = appointmentDate
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(appointment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(Constant.ApiUrl + "api/Appointment/SetAppointment", content);
            var resultJson = response.Content.ReadAsStringAsync().Result;
            var resultObject = JsonConvert.DeserializeObject(resultJson);
            
            if (response.IsSuccessStatusCode)
            {
                return int.Parse(resultObject.ToString());
            }
            else
            {
                return -100;
            }

        }

        public static async Task<bool> PutAppointmentAsync(int id, DateTime appointmentDate, string location)
        {
            var appointment = new AppointmentModel()
            {
                AppointmentDate = appointmentDate,
                Location = location
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(appointment);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await httpClient.PutAsync(Constant.ApiUrl + "Appointment/UpdateAppointment/" + id, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<bool> DeleteAppointmentAsync(int userId)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(Constant.ApiUrl + "Appointment/DeleteAppointment/" + userId);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<List<LocationModel>> GetLocations()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(Constant.ApiUrl + "api/Location/GetLocations");

            var locations = JsonConvert.DeserializeObject<List<LocationModel>>(json);

            return locations;
        }

        public static async Task<int> GetAppointmentId(DateTime appointment)
        {
            var donorAppointment = new AppointmentModel
            {
                AppointmentDate = appointment
            };

            var httpclient = new HttpClient();
            var json = JsonConvert.SerializeObject(donorAppointment);
            
            var response = await httpclient.GetAsync(Constant.ApiUrl + "api/Appointment/GetAppointmentId/" + appointment);
            var jsonData = await httpclient.GetStringAsync(Constant.ApiUrl + "api/Appointment/GetAppointmentId/" + appointment);
            var appointmentId = JsonConvert.DeserializeObject<int>(jsonData);

            return appointmentId;
            
            
        }
    }
}

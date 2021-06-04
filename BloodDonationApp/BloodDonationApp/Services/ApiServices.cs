using BloodDonationApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;


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
                return (int)resultObject;
            }
            else
            {
                return -100;
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
                return (int)resultObject;
            }
            else
            {
                return -100;
            }
        }

        public static async Task<DonorModel> GetDonorCredentials (int userId)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Constant.ApiUrl + "api/Donor/GetDonorDetail" + userId);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var donor = JsonConvert.DeserializeObject<DonorModel>(jsonData);
                return donor;
            }
            else
            {
                return null;
            }

           
        }
    }
}

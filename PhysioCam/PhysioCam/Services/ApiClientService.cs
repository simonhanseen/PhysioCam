using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhysioCam.Interfaces;
using PhysioCam.Models;

namespace PhysioCam.Services
{
    public class ApiClientService : IApiClientService
    {
        public string Url => "https://fast-castle-50377.herokuapp.com/";
        private string _strAuthorizationKey = "";

        private HttpClient _client;
        
        public HttpClient Client => _client ?? (_client = GetClient());

        public ApiClientService()
        {

        }

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            
            if(string.IsNullOrEmpty(_strAuthorizationKey))
            {
                var login = new Login();
                var user = new User { identifier = "student", password = "Student1234" };
                login.user = user;
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                client.Timeout = new TimeSpan(0, 0, 0, 10);

                try
                {
                    var response = client.PostAsync(Url + "auth/local", content).Result;
                    
                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    var token = JsonConvert.DeserializeObject<Login>(responseBody)?.jwt;
                    
                    _strAuthorizationKey = token;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",_strAuthorizationKey);
            return client;
        }

        public async Task<string> GetStringAsync(string subUrl)
        {
            return await Client.GetStringAsync(Url + subUrl);
        }

        public async Task<string> PostJsonAsync(string subUrl, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await Client.PostAsync(Url + subUrl, content);
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsStringAsync();
        }
    }
}
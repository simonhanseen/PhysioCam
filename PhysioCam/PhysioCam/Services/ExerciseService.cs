using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhysioCam.Interfaces;
using PhysioCam.Models;
using PhysioCam.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ExerciseService))]
namespace PhysioCam.Services
{
    public class ExerciseService : IExerciseService
    {
        private const string Url = "https://fast-castle-50377.herokuapp.com/";
        private string _strAuthorizationKey = "";

        public ExerciseService()
        {

        }

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            
            if(string.IsNullOrEmpty(_strAuthorizationKey))
            {
                Login login = new Login();
                User user = new User { identifier = "student", password = "Student1234" };
                login.user = user;
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                client.Timeout = new TimeSpan(0, 0, 0, 10);

                try
                {
                    var response = await client.PostAsync(Url + "auth/local", content);
                    
                    var responseBody = await response.Content.ReadAsStringAsync();
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
        
        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            var client = await GetClient();

            if (client == null) return new[] {new Exercise {Title = "No result found..."}};
            
            var strResult = await client.GetStringAsync(Url + "Exercises");
            
            return JsonConvert.DeserializeObject<IEnumerable<Exercise>>(strResult);

        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhysioCam.Interfaces;
using PhysioCam.Models;
using Xamarin.Forms;

namespace PhysioCam.Services
{
    public class UserService : IUserService
    {
        private readonly IApiClientService _clientService;

        public AppUser User { get; private set; }

        public UserService()
        {
            _clientService = DependencyService.Get<IApiClientService>();
        }

        public async Task<AppUser> Login(string username)
        {
            var strResult = await _clientService.GetStringAsync("app-users");
            
            var users = JsonConvert.DeserializeObject<IEnumerable<AppUser>>(strResult);
            User = users.FirstOrDefault(u => u.Name == username);

            return User;
        }
    }
}
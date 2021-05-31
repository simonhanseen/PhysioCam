using System.Threading.Tasks;
using PhysioCam.Models;

namespace PhysioCam.Interfaces
{
    public interface IUserService
    {
        AppUser CurrentUser { get; }
        Task<AppUser> Login(string username);
    }
}
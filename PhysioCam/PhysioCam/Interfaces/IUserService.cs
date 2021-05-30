using System.Threading.Tasks;
using PhysioCam.Models;

namespace PhysioCam.Interfaces
{
    public interface IUserService
    {
        AppUser User { get; }
        Task<AppUser> Login(string username);
    }
}
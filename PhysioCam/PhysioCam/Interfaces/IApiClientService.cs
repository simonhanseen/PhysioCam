using System.Net.Http;
using System.Threading.Tasks;

namespace PhysioCam.Interfaces
{
    public interface IApiClientService
    {
        string Url { get; }
        HttpClient Client { get; }
        Task<string> GetStringAsync(string subUrl);
    }
}
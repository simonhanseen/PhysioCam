using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PhysioCam.Models;

namespace PhysioCam.Interfaces
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetExercises();
    }
}
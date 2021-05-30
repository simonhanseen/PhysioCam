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
        private readonly IUserService _userService;

        public ExerciseService()
        {
            _userService = DependencyService.Get<IUserService>();
        }

        public IEnumerable<Exercise> GetExercises()
        {
            return _userService.User.Exercises;
        }
    }
}
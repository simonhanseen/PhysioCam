using System;
using System.Collections.Generic;
using System.Linq;
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
            return _userService.CurrentUser.Exercises;
        }

        public async Task SaveExercisePlan(ExercisePlan exercisePlan)
        {
            var apiService = DependencyService.Get<IApiClientService>();
            
            var exercisePlanDto = new ExercisePlanDto
            {
                Title = exercisePlan.Title,
                Description = exercisePlan.Description
            };

            var json = "";

            try
            {
                foreach (var exercise in exercisePlan.Exercises)
                {
                    var exerciseDto = new ExerciseDto
                    {
                        Title = exercise.Title,
                        Description = exercise.Description
                    };
                    
                    exerciseDto.AppUsers.Add(new {id = exercise.AppUsers.FirstOrDefault().Id});
                        
                    var exerciseJson = JsonConvert.SerializeObject(exerciseDto);
                    var result = await apiService.PostJsonAsync("exercises", exerciseJson);
                    
                    var resultingExercise = JsonConvert.DeserializeObject<ExerciseDto>(result);
                    exercisePlanDto.Exercises.Add(new {id = resultingExercise.Id});
                }
                
                json = JsonConvert.SerializeObject(exercisePlanDto);
                await apiService.PostJsonAsync("exercise-plans", json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Couldn't post the plan due to the following error:\n{e.Message}");
                Console.WriteLine($"Tried to send following request:\n{json}");
                throw;
            }
        }
    }
}
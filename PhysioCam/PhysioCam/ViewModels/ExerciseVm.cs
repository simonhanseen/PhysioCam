using System.Collections.Generic;
using System.Windows.Input;
using PhysioCam.Models;
using Xamarin.Forms;

namespace PhysioCam.ViewModels
{
    public class ExerciseVm : PhysioCamVm
    {
        public delegate void AddExercise(Exercise exercise);

        private AddExercise _addExercise;

        public void Attach(AddExercise ex)
        {
            _addExercise += ex;
        }
        
        public ExerciseVm(Exercise exercise)
        {
            if (exercise == null)
            {
                _exercise = new Exercise();
                NewExercise = true;
            }
            else
            {
                _exercise = exercise;
            }

            SaveToProgramCommand = new Command(async() =>
            {
                _addExercise(_exercise);
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        private Exercise _exercise;

        public bool NewExercise { get; }

        public string Name
        {
            get => _exercise.Name;
            set => _exercise.Name = value;
        }

        public string Description
        {
            get => _exercise.Description;
            set => _exercise.Description = value;
        }
        
        public bool StandardExercise { get; set; }

        public ICollection<string> Images { get; set; }

        public ICommand SaveToProgramCommand { get; set; }
    }
}
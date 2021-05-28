using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PhysioCam.Models;
using PhysioCam.View;
using Xamarin.Forms;

namespace PhysioCam.ViewModels
{
    public class ProgramPageVm : PhysioCamVm
    {
        public ProgramPageVm()
        {
            
        }
        
        public ProgramPageVm(IEnumerable<Exercise> exercises = null)
        {
            if (exercises == null) return;
            Exercises = (ObservableCollection<Exercise>) exercises;
            NoItemsInList = Exercises.Count == 0;

            // NewExerciseCommand = new Command(() =>
            // {
            //     var ex = new ExerciseVm(null);
            //     ex.Attach(AddExercise);
            //     var page = new ExercisePage(ex);
            //     NavigateCommand.Execute(page);
            // });
        }

        // public ObservableCollection<ExerciseOld> Exercises { get; set; } = new ObservableCollection<ExerciseOld>();
        public ObservableCollection<Exercise> Exercises { get; set; }

        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
            NoItemsInList = Exercises.Count == 0;
            OnPropertyChanged(nameof(Exercises));
        }

        public ICommand NewExerciseCommand { get; protected set; }

        private bool _noItemsInList = true;
        public bool NoItemsInList
        {
            get => _noItemsInList;
            set
            {
                if (_noItemsInList == value) return;
                _noItemsInList = value;
                OnPropertyChanged(nameof(NoItemsInList));
            }
        }
    }
}
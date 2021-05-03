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
        public Program Program { get; set; }

        public ProgramPageVm()
        {
            NewExerciseCommand = new Command(() =>
            {
                var ex = new ExerciseVm(null);
                ex.Attach(AddExercise);
                var page = new ExercisePage(ex);
                NavigateCommand.Execute(page);
            });
        }

        public ObservableCollection<Exercise> Exercises { get; set; } = new ObservableCollection<Exercise>();

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
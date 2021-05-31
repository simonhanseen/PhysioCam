using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Newtonsoft.Json;
using PhysioCam.Models;
using PhysioCam.View;
using Xamarin.Forms;

namespace PhysioCam.ViewModels
{
    public class ExercisePlanVm : PhysioCamVm
    {
        private ExercisePlan _exercisePlan;

        public string Title
        {
            get => _exercisePlan.Title;
            set => _exercisePlan.Title = value;
        }
        
        public string Description
        {
            get => _exercisePlan.Description;
            set => _exercisePlan.Description = value;
        }
        
        public ObservableCollection<Exercise> Exercises { get; set; }

        public ExercisePlanVm() : this(new ExercisePlan())
        {
        }

        public ExercisePlanVm(ExercisePlan exercisePlan)
        {
            _exercisePlan = exercisePlan;
            
            Exercises = new ObservableCollection<Exercise>(_exercisePlan.Exercises);
            
            NewExerciseCommand = new Command(async() =>
            {
                var vm = new ExerciseVm();
                vm.Attach(AddExercise);
                
                var page = new ExercisePage(vm);
                
                NavigateCommand.Execute(page);
            });

            SavePlanCommand = new Command(async () =>
            {
                NavigateCommand.Execute(new SendPage(_exercisePlan));
            });
        }
        
        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
            _exercisePlan.Exercises.Add(exercise);
            ItemsInList = Exercises.Count > 0;
            OnPropertyChanged(nameof(Exercises));
        }

        public ICommand NewExerciseCommand { get; protected set; }
        public ICommand SavePlanCommand { get; protected set; }

        private bool _itemsInList;
        public bool ItemsInList
        {
            get => _itemsInList;
            set
            {
                if (_itemsInList == value) return;
                _itemsInList = value;
                OnPropertyChanged(nameof(ItemsInList));
                OnPropertyChanged(nameof(NoItemsInList));
            }
        }

        public bool NoItemsInList => !_itemsInList;
    }
}
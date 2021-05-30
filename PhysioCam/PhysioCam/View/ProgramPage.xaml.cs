using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PhysioCam.Interfaces;
using PhysioCam.Models;
using PhysioCam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgramPage : ContentPage
    {
        public ProgramPage()
        {
            InitializeComponent();
        }
        
        protected override async void OnAppearing()
        {
            var service = DependencyService.Get<IExerciseService>();
            var exercises = service.GetExercises();
            BindingContext = new ProgramPageVm(new ObservableCollection<Exercise>(exercises));
        }

        private void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            var ex = (Exercise)((ListView)sender).SelectedItem;
            Navigation.PushAsync(new ExercisePage(new ExerciseVm(ex)));
            ((ListView)sender).SelectedItem = null;
        }
    }
}
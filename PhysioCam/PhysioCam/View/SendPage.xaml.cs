using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysioCam.Interfaces;
using PhysioCam.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendPage : ContentPage
    {
        private ExercisePlan _exercisePlan;
        
        public SendPage(ExercisePlan exercisePlan)
        {
            InitializeComponent();
            _exercisePlan = exercisePlan;
            BindingContext = _exercisePlan;
        }

        private async void SaveBtn_OnClicked(object sender, EventArgs e)
        {
            var exerciseService = DependencyService.Get<IExerciseService>();

            try
            {
                await exerciseService.SaveExercisePlan(_exercisePlan);
                await DisplayAlert("Success", "The plan was saved", "OK");
                await Navigation.PopToRootAsync();
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not save plan.", "OK");
            }
        }
    }
}
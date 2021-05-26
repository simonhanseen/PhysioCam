using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void PatientHistoryBtnHandler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PatientHistory());
        }

        private void NewTrainingProgramBtnHandler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProgramPage());
        }

        private void PatientsBtnHandler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PatientPage());
        }

        private void ExercisesProgramBtnHandler(object sender, EventArgs e)
        {
            DisplayAlert("Not implemented", "This feature is not yet implemented", "OK");
            //Navigation.PushAsync(new StardardExercisesPage());
        }
    }
}
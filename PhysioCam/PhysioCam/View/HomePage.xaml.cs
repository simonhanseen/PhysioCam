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
            //Nav Link
        }

        private void NewTrainingProgramBtnHandler(object sender, EventArgs e)
        {
            //Nav Link
        }
    }
}
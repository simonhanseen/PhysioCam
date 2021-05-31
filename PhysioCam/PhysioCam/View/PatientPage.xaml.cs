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
    public partial class PatientPage : ContentPage
    {
        public PatientPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        public List<Patient> Patients { get => PatientData(); }

        private List<Patient> PatientData()
        {
            var tempList = new List<Patient>();
            tempList.Add(new Patient { Program = "1", Name = "Mysha Bauer" });
            tempList.Add(new Patient { Program = "2", Name = "Arvin Dixon" });
            tempList.Add(new Patient { Program = "3", Name = "Vicky Bender" });
            tempList.Add(new Patient { Program = "4", Name = "Maegan Winters" });
            tempList.Add(new Patient { Program = "5", Name = "Theodora Mackie" });
            tempList.Add(new Patient { Program = "6", Name = "Ann Holland" });

            return tempList;
        }
    }
    public class Patient
    {
        public string Program { get; set; }
        public string Name { get; set; }
    }
}
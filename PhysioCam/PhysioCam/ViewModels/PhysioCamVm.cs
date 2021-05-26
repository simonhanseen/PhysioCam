using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PhysioCam.Annotations;
using Xamarin.Forms;

namespace PhysioCam.ViewModels
{
    public class PhysioCamVm : INotifyPropertyChanged
    {
        public PhysioCamVm()
        {
            NavigateCommand = new Command<Page>(async page =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            });
        }
        
        public ICommand NavigateCommand { get; private set; }
        
        
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
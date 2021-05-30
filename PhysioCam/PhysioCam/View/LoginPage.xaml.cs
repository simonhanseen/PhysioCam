﻿using System;
using System.Threading.Tasks;
using PhysioCam.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginBtnHandler(object sender, EventArgs e)
        {
            var userService = DependencyService.Get<IUserService>();
            await userService.Login("Marianne");
            
            App.Current.MainPage = new NavigationPage(new HomePage());
        }

        private async void SignUpBtnHandler(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
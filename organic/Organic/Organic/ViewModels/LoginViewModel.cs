using System;
using System.Collections.Generic;
using System.Text;


namespace Organic.ViewModels
{
    using GalaSoft.MvvmLight.Command;    
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel:BaseViewModel
        
    {        
        #region Attributes        
        private bool isRunning;
        private string password;
        private bool isEnabled;
        #endregion
        #region Properties
        public string Email { get; set; }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }                        

        }        

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    "You must Enter an Email", 
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must Enter a Password",
                    "Accept");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "chaly.com" || this.Password != "123")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password are Incorrects",                    
                    "Accept");
                this.Password = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;
            await Application.Current.MainPage.DisplayAlert(
                   "Ok",
                   "Good Done",
                   "Accept");
        }
        #endregion
    }
}

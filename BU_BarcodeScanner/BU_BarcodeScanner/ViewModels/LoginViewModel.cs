﻿using BU_BarcodeScanner.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BU_BarcodeScanner.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        private string _cashierId;
        public string CashierId
        {
            get => _cashierId;
            set
            {
                if (_cashierId != value)
                {
                    _cashierId = value;
                    OnPropertyChanged(nameof(CashierId));
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private bool _showInvalidText;
        public bool ShowInvalidText
        {
            get => _showInvalidText;
            set
            {
                if (_showInvalidText != value)
                {
                    SetProperty(ref _showInvalidText, value);
                    OnPropertyChanged(nameof(ShowInvalidText));
                }
            }
        }

        public LoginViewModel()
        {
            bool isLoggedIn = Preferences.Get("isLoggedIn", false);

            if(isLoggedIn)
                Shell.Current.GoToAsync($"//{nameof(ScannerPage)}");

            LoginCommand = new Command(OnLoginClicked);
            
        }


        private async void OnLoginClicked(object obj)
        {
            if (CashierId == "cash001" && Password == "passpass")
            {
                Preferences.Set("isLoggedIn", true);
                await Shell.Current.GoToAsync($"//{nameof(ScannerPage)}");
            }

            else
            {
                ShowInvalidText = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual async void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));    
        }
    }
}

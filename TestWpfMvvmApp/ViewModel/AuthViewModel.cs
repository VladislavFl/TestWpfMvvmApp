﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TestWpfMvvmApp.Utilities;
using TestWpfMvvmApp.Services;
using TestWpfMvvmApp.Services.Interfaces;

namespace TestWpfMvvmApp.ViewModel
{
    internal class AuthViewModel : ViewModelBase
    {
        private string _login = string.Empty;
        private string _password = string.Empty;
        private readonly IAuthStateService _authStateService;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand => new RelayCommand(o => AuthMethod());

        private void AuthMethod()
        {
            _authStateService.SetUserAuthorized(true);
            MessageBox.Show("ffgg");
        }

        public AuthViewModel(IAuthStateService authStateService)
        {
            _authStateService = authStateService;
        }
    }
}

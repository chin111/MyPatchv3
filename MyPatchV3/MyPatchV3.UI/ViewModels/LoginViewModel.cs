using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

using MyPatchV3.UI.DataServices;
using MyPatchV3.UI.DataServices.Base;
using MyPatchV3.UI.Validations;
using MyPatchV3.UI.Helpers;

namespace MyPatchV3.UI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;
        private bool _isValid;
        private bool _isEnabled;

        private readonly IAuthenticationService _authenticationService;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public ValidatableObject<string> Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged(() => IsEnabled);
            }
        }

        public ICommand SignInCommand => new Command(SignInAsync);

        public ICommand ValidateCommand
        {
            get { return new Command(() => Enable()); }
        }

        private async void SignInAsync()
        {
            IsBusy = true;
            IsValid = true;
            bool isValid = Validate();
            bool isAuthenticated = false;

            if (isValid)
            {
                
                try
                {
                    isAuthenticated = await _authenticationService.LoginAsync(UserName.Value, Password.Value);
                }
                catch (ServiceAuthenticationException)
                {
                    await DialogService.ShowAlertAsync("Invalid credentials", "Login failure", "Try again");
                }
                catch (Exception ex) when (ex is WebException || ex is HttpRequestException)
                {
                    Debug.WriteLine($"[SignIn] Error signing in: {ex}");
                    await DialogService.ShowAlertAsync("Communication error", "Error", "Ok");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[SignIn] Error signing in: {ex}");
                }

                //isAuthenticated = true;
            }
            else
            {
                IsValid = false;

                bool isValidUser = _userName.Validate();
                if (!isValidUser)
                {
                    await DialogService.ShowAlertAsync("Username should not be empty.", "Error", "Ok");
                }
                else
                {
                    await DialogService.ShowAlertAsync("Password should not be empty.", "Error", "Ok");
                }
            }

            if (isAuthenticated)
            {
                if (Settings.UserType == "DM")
                {
                    // Employer, Go to choose an employee
                    await NavigationService.NavigateToAsync<EmployeeListViewModel>();
                }
                else
                {
                    // Employee, Go straight to Sync page
                    await NavigationService.NavigateToAsync<SyncViewModel>();
                }
            }

            IsBusy = false;
        }

        private bool Validate()
        {
            bool isValidUser = _userName.Validate();
            bool isValidPassword = _password.Validate();

            return isValidUser && isValidPassword;
        }

        private void Enable()
        {
            IsEnabled = !string.IsNullOrEmpty(UserName.Value) &&
                !string.IsNullOrEmpty(Password.Value);
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Username should not be empty" });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password should not be empty" });
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}

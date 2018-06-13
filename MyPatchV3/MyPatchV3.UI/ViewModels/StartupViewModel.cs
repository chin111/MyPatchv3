using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace MyPatchV3.UI.ViewModels
{
    public class StartupViewModel : ViewModelBase
    {
        public StartupViewModel()
        {

        }
        public ICommand GoToLoginCommand => new Command(GoToLogin);

        public ICommand GoToMainCommand => new Command(GoToMain);

        private async void GoToMain()
        {
            await NavigationService.NavigateToAsync<MainViewModel>();
        }

        private async void GoToLogin()
        {
            try
            {
                await NavigationService.NavigateToAsync<LoginViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}

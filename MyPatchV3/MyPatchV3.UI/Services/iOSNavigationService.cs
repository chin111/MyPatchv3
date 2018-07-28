using System;
using System.Threading.Tasks;
using MyPatchV3.UI.DataServices;
using MyPatchV3.UI.Pages;
using MyPatchV3.UI.ViewModels;
using MyPatchV3.UI.ViewModels.Base;
using Xamarin.Forms;

namespace MyPatchV3.UI.Services
{
    public class iOSNavigationService : NavigationService
    {
        private Type _requestedPageType;
        private object _requestedNavigationParameter;

        public iOSNavigationService(IAuthenticationService authenticationService) : base(authenticationService)
        {
            CreatePageViewModelMappings();

            MessagingCenter.Subscribe<iOSMainPage>(this, MessengerKeys.iOSMainPageCurrentChanged, OnMainPageCurrentChanged);
        }

        public override Task RemoveLastFromBackStackAsync()
        {
            var mainPage = CurrentApplication.MainPage as iOSMainPage;

            if (mainPage != null)
            {
                var currentNavigation = mainPage.CurrentPage as CustomNavigationPage;

                
            }

            return Task.FromResult(true);
        }

        protected override async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);
            _requestedPageType = page.GetType();
            _requestedNavigationParameter = parameter;

            if (page is iOSMainPage)
            {
                InitalizeMainPage(page as iOSMainPage);
                await InitializeTabPageCurrentPageViewModelAsync(parameter);
            }
            else if (page is LoginPage)
            {
                CurrentApplication.MainPage = new CustomNavigationPage(page);
                await InitializePageViewModelAsync(page, parameter);
            }
            else if (CurrentApplication.MainPage is iOSMainPage)
            {
                var mainPage = CurrentApplication.MainPage as iOSMainPage;
                bool tabPageFound = mainPage.TrySetCurrentPage(page);

                if (!tabPageFound)
                {
                    await mainPage.CurrentPage.Navigation.PushAsync(page);
                    await InitializePageViewModelAsync(page, parameter);
                }
            }
            else
            {
                var navigationPage = CurrentApplication.MainPage as CustomNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new CustomNavigationPage(page);
                }

                await InitializePageViewModelAsync(page, parameter);
            }
        }

        private Task InitializePageViewModelAsync(Page page, object parameter)
        {
            return (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        private Task InitializeTabPageCurrentPageViewModelAsync(object parameter)
        {
            var mainPage = CurrentApplication.MainPage as iOSMainPage;
            return ((mainPage.CurrentPage as CustomNavigationPage).CurrentPage.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        private void InitalizeMainPage(iOSMainPage mainPage)
        {
            CurrentApplication.MainPage = mainPage;

            var homePage = CreateAndBindPage(typeof(HomeViewModel), null);
            mainPage.AddPage(homePage, "Home");

            //var myRidesPage = CreateAndBindPage(typeof(MyRidesViewModel), null);
            //mainPage.AddPage(myRidesPage, "My Rides");

            //var bookingPage = CreateAndBindPage(typeof(BookingViewModel), null);
            //mainPage.AddPage(bookingPage, "Upcoming");

            //var reportPage = CreateAndBindPage(typeof(ReportIncidentViewModel), null);
            //mainPage.AddPage(reportPage, "Report");

            //var profilePage = CreateAndBindPage(typeof(ProfileViewModel), null);
            //mainPage.AddPage(profilePage, "Profile");
        }

        private async void OnTabPageAppearing(object sender, EventArgs e)
        {
            await InitializeTabPageCurrentPageViewModelAsync(null);
        }

        private void CreatePageViewModelMappings()
        {
            if (_mappings.ContainsKey(typeof(MainViewModel)))
            {
                _mappings[typeof(MainViewModel)] = typeof(iOSMainPage);
            }
            else
            {
                _mappings.Add(typeof(MainViewModel), typeof(iOSMainPage));
            }
        }

        private async void OnMainPageCurrentChanged(iOSMainPage mainPage)
        {
            object parameter = null;

            CustomNavigationPage navigation = mainPage.CurrentPage as CustomNavigationPage;


            await InitializeTabPageCurrentPageViewModelAsync(parameter);
        }
    }
}
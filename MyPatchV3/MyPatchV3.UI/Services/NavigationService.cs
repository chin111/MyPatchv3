//using MyPatchV3.UI.DataServices;
//using MyPatchV3.UI.Models.ReportIncident;
using MyPatchV3.UI.Pages;
//using MyPatchV3.UI.Pages.SignUp;
using MyPatchV3.UI.ViewModels;
using MyPatchV3.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyPatchV3.UI.Services
{
    public class NavigationService : INavigationService
    {
        //private readonly IAuthenticationService _authenticationService;
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }

        //public NavigationService(IAuthenticationService authenticationService)
        //{
        //    _authenticationService = authenticationService;
        //    _mappings = new Dictionary<Type, Type>();

        //    CreatePageViewModelMappings();
        //    CreateMessengerSubscriptions();
        //}
        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
            CreateMessengerSubscriptions();
        }

        public Task InitializeAsync()
        {
            //if (_authenticationService.IsAuthenticated)
            //{
            //    return NavigateToAsync<MainViewModel>();
            //}
            //else
            //{
            //    return NavigateToAsync<LoginViewModel>();
            //}

            return NavigateToAsync<StartupViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is MainPage)
            {
                var mainPage = CurrentApplication.MainPage as MainPage;
                await mainPage.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            var mainPage = CurrentApplication.MainPage as MainPage;

            if (mainPage != null)
            {
                mainPage.Detail.Navigation.RemovePage(
                    mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is MainPage)
            {
                CurrentApplication.MainPage = page;
            }
            else if (page is LoginPage)
            {
                CurrentApplication.MainPage = new CustomNavigationPage(page);
            }
            else if (CurrentApplication.MainPage is MainPage)
            {
                var mainPage = CurrentApplication.MainPage as MainPage;
                var navigationPage = mainPage.Detail as CustomNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    navigationPage = new CustomNavigationPage(page);
                    mainPage.Detail = navigationPage;
                }

                mainPage.IsPresented = false;
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
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            if (page is IPageWithParameters)
            {
                ((IPageWithParameters)page).InitializeWith(parameter);
            }

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(StartupViewModel), typeof(StartupPage));
            _mappings.Add(typeof(LoginViewModel), typeof(LoginPage));
            _mappings.Add(typeof(HomeViewModel), typeof(HomePage));
            _mappings.Add(typeof(MainViewModel), typeof(MainPage));
        }

        private void CreateMessengerSubscriptions()
        {
            //MessagingCenter.Subscribe<ReportedIssue>(this, MessengerKeys.GoBackFromReportRequest, GoBackFromReportRequested);
        }

        private async void GoBackFromReportRequested()
        {
            if (Device.RuntimePlatform != Device.iOS)
            {
                await NavigateBackAsync();
            }
        }
    }
}
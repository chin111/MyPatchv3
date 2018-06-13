//using MyPatchV3.UI.DataServices;
//using MyPatchV3.UI.DataServices.Base;
//using MyPatchV3.UI.DataServices.Interfaces;
using MyPatchV3.UI.Services;
using MyPatchV3.UI.Services.Interfaces;
//using MyPatchV3.UI.ViewModels.SignUp;
using Unity;
using Unity.Lifetime;
using System;

namespace MyPatchV3.UI.ViewModels.Base
{
    public class ViewModelLocator
    {
        private readonly IUnityContainer _unityContainer;

        private static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected ViewModelLocator()
        {
            _unityContainer = new UnityContainer();

            // Providers
            //_unityContainer.RegisterType<IRequestProvider, RequestProvider>();
            //_unityContainer.RegisterType<ILocationProvider, LocationProvider>();
            _unityContainer.RegisterType<IMediaPickerService, MediaPickerService>();

            // Services
            _unityContainer.RegisterType<IDialogService, DialogService>();
            RegisterSingleton<INavigationService, NavigationService>();

            // Data services
            //_unityContainer.RegisterType<IAuthenticationService, AuthenticationService>();
            //_unityContainer.RegisterType<IProfileService, ProfileService>();
            //_unityContainer.RegisterType<IRidesService, RidesService>();
            //_unityContainer.RegisterType<IEventsService, EventsService>();
            //_unityContainer.RegisterType<IWeatherService, OpenWeatherMapService>();
            //_unityContainer.RegisterType<IFeedbackService, FeedbackService>();

            // View models
            _unityContainer.RegisterType<StartupViewModel>();
            _unityContainer.RegisterType<LoginViewModel>();
            _unityContainer.RegisterType<HomeViewModel>();
            _unityContainer.RegisterType<MainViewModel>();
            //_unityContainer.RegisterType<MenuViewModel>();
            //_unityContainer.RegisterType<ProfileViewModel>();
            //_unityContainer.RegisterType<UserViewModel>();
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _unityContainer.Resolve(type);
        }

        public void Register<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}

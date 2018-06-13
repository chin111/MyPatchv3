using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using MyPatchV3.UI.Services;
using MyPatchV3.UI.ViewModels.Base;
using MyPatchV3.UI.Utils;

namespace MyPatchV3.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AdaptColorsToHexString();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            base.OnStart();

            if (Device.RuntimePlatform != Device.WinPhone && Device.RuntimePlatform != Device.UWP)
            {
                await InitNavigation();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        private void AdaptColorsToHexString()
        {
            for (var i = 0; i < this.Resources.Count; i++)
            {
                var key = this.Resources.Keys.ElementAt(i);
                var resource = this.Resources[key];

                if (resource is Color)
                {
                    var color = (Color)resource;
                    this.Resources.Add(key + "HexString", color.ToHexString());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyPatchV3.UI.ViewModels.Base;
using MyPatchV3.UI.ViewModels;

namespace MyPatchV3.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartupPage : ContentPage
	{
        private Timer transitionTimer;

        public StartupPage()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var osVersionString = ViewModelLocator.Instance.Resolve<IOperatingSystemVersionProvider>().GetOperatingSystemVersionString();

            //transitionTimer = new Timer(this.TransitionPage, null, 2000, System.Threading.Timeout.Infinite);

            await Task.Delay(2000);

            var startupViewModel = BindingContext as StartupViewModel;

            if (startupViewModel != null)
            {
                startupViewModel.GoToLoginCommand.Execute(null);
            }
        }

        public void TransitionPage(object state)
        {
            var startupViewModel = BindingContext as StartupViewModel;

            if (startupViewModel != null)
            {
                startupViewModel.GoToLoginCommand.Execute(null);
            }
        }
    }
}
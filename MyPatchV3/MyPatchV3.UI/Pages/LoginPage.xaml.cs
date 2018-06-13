using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyPatchV3.UI.ViewModels.Base;

namespace MyPatchV3.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //var osVersionString = ViewModelLocator.Instance.Resolve<IOperatingSystemVersionProvider>()
            //    .GetOperatingSystemVersionString();

            //if (Device.OS == TargetPlatform.iOS && osVersionString == "10.0.2")
            //{
            //    //SignInButton.BackgroundColor = Color.Black;
            //}
        }
    }
}
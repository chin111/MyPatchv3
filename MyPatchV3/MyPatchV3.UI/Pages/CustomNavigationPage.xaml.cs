﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPatchV3.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomNavigationPage : NavigationPage
    {
		public CustomNavigationPage () : base()
        {
			InitializeComponent ();
		}
        public CustomNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}
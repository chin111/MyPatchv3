using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyPatchV3.UI.Helpers;
using MyPatchV3.UI.ViewModels.Base;

namespace MyPatchV3.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class iOSMainPage : TabbedPage
    {
        private Page _previousPage;
        public iOSMainPage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();

            CurrentPageChanged += OnCurrentPageChanged;
        }
        public void AddPage(Page page, string title)
        {
            var navigationPage = new CustomNavigationPage(page)
            {
                Title = title,
                Icon = GetIconForPage(page)
            };

            if (_previousPage == null)
            {
                _previousPage = page;
            }

            Children.Add(navigationPage);
        }

        public bool TrySetCurrentPage(Page requiredPage)
        {
            return TrySetCurrentPage(requiredPage.GetType());
        }

        public bool TrySetCurrentPage(Type requiredPageType)
        {
            CustomNavigationPage page = GetTabPageWithInitial(requiredPageType);

            if (page != null)
            {
                CurrentPage = null;
                CurrentPage = page;
            }

            return page != null;
        }

        public async Task ClearNavigationForPage(Type type)
        {
            CustomNavigationPage page = GetTabPageWithInitial(type);

            if (page != null)
            {
                await page.Navigation.PopToRootAsync(false);
            }
        }

        private CustomNavigationPage GetTabPageWithInitial(Type type)
        {
            CustomNavigationPage page = Children.OfType<CustomNavigationPage>()
                                                .FirstOrDefault(p =>
                                                {
                                                    return p.CurrentPage.Navigation.NavigationStack.Count > 0
                                                        ? p.CurrentPage.Navigation.NavigationStack[0].GetType() == type
                                                        : false;
                                                });

            return page;
        }

        private string GetIconForPage(Page page)
        {
            string icon = string.Empty;

            if (page is HomePage)
            {
                icon = "menu_ic_home";
            }

            return icon;
        }

        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            if (CurrentPage == null)
            {
                return;
            }

            if (!CurrentPage.IsEnabled)
            {
                CurrentPage = _previousPage;
            }
            else
            {
                _previousPage = CurrentPage;
                MessagingCenter.Send(this, MessengerKeys.iOSMainPageCurrentChanged);
            }
        }
    }
}
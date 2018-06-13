using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Linq;
using Xamarin.Forms;

using MenuItem = MyPatchV3.UI.Models.MenuItem;
using MyPatchV3.UI.ViewModels.Base;
using MyPatchV3.UI.Helpers;

namespace MyPatchV3.UI.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ICommand ItemSelectedCommand => new Command<MenuItem>(OnSelectItem);

        public ICommand LogoutCommand => new Command(OnLogout);

        ObservableCollection<MenuItem> menuItems = new ObservableCollection<MenuItem>();

        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
                return menuItems;
            }
            set
            {
                menuItems = value;
                RaisePropertyChanged(() => MenuItems);
            }
        }
        public MenuViewModel()
        {
            InitMenuItems();
        }

        public override async Task InitializeAsync(object navigationData)
        {
            
        }

        private void InitMenuItems()
        {
            //MenuItems.Add(new MenuItem
            //{
            //    Title = "My Rides",
            //    MenuItemType = MenuItemType.MyRides,
            //    ViewModelType = Device.Idiom == TargetIdiom.Desktop ? typeof(UwpMyRidesViewModel) : typeof(MyRidesViewModel),
            //    IsEnabled = true
            //});

            //MenuItems.Add(new MenuItem
            //{
            //    Title = "Upcoming ride",
            //    MenuItemType = MenuItemType.UpcomingRide,
            //    ViewModelType = typeof(BookingViewModel),
            //    IsEnabled = Settings.CurrentBookingId != 0
            //});

            //MenuItems.Add(new MenuItem
            //{
            //    Title = "Report",
            //    MenuItemType = MenuItemType.ReportIncident,
            //    ViewModelType = typeof(ReportIncidentViewModel),
            //    IsEnabled = Settings.CurrentBookingId != 0
            //});

            //MenuItems.Add(new MenuItem
            //{
            //    Title = "Profile",
            //    MenuItemType = MenuItemType.Profile,
            //    ViewModelType = typeof(ProfileViewModel),
            //    IsEnabled = true
            //});
        }

        private async void OnSelectItem(MenuItem item)
        {
            if (item.IsEnabled)
            {
                object parameter = null;

                await NavigationService.NavigateToAsync(item.ViewModelType, parameter);
            }
        }

        private async void OnLogout()
        {
            //await _authenticationService.LogoutAsync();
            //await NavigationService.NavigateToAsync<LoginViewModel>();
        }
        
    }
}

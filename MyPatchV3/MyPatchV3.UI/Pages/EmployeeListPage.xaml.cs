using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyPatchV3.UI.Models;

namespace MyPatchV3.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeeListPage : ContentPage
	{
		public EmployeeListPage ()
		{
			InitializeComponent ();
		}

        private void Items_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            var tappedEmployee = (Employee)e.Item;
            Console.Write(tappedEmployee.Employee_ID);

            tappedEmployee.IsSelected = true;
        }
    }
}
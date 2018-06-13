using Acr.UserDialogs;
using System.Threading.Tasks;
using MyPatchV3.UI.Services.Interfaces;

namespace MyPatchV3.UI.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }
    }
}

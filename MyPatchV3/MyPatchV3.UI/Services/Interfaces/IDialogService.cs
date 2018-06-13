using System.Threading.Tasks;

namespace MyPatchV3.UI.Services.Interfaces
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}

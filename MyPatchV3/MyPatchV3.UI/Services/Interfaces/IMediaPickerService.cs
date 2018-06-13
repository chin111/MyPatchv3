using System.Threading.Tasks;

namespace MyPatchV3.UI.Services.Interfaces
{
    public interface IMediaPickerService
    {
        Task<string> PickImageAsBase64String();
    }
}

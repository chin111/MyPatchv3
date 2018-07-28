using System.Threading.Tasks;

namespace MyPatchV3.UI.DataServices
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }

        Task<bool> LoginAsync(string userName, string password);

        Task LogoutAsync();

        string GetCurrentUserId();

        string GetCurrentUserType();
    }
}

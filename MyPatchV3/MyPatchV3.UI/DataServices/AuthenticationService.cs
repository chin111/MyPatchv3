using MyPatchV3.UI.DataServices.Base;
using MyPatchV3.UI.Helpers;
using MyPatchV3.UI.Models;
using MyPatchV3.DL.Models;
using System;
using System.Threading.Tasks;

namespace MyPatchV3.UI.DataServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRequestProvider _requestProvider;

        public bool IsAuthenticated => !string.IsNullOrEmpty(Settings.UserId);

        public AuthenticationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            var auth = new AuthenticationRequest
            {
                UserID = userName,
                Password = password,
                MacAddr = ""
            };

            UriBuilder builder = new UriBuilder(GlobalSettings.AuthenticationEndpoint);
            builder.Path = "MyPatchAPI/api/verifylogin";

            string uri = builder.ToString();

            AuthenticationResponse authenticationInfo = await _requestProvider.PostAsync<AuthenticationRequest, AuthenticationResponse>(uri, auth);
            Settings.UserId = authenticationInfo.User_ID;
            Settings.UserType = authenticationInfo.User_Type;
            Settings.UserActive = authenticationInfo.IsActive;
            Settings.UserMsg = authenticationInfo.User_Msg;

            return true;
        }

        public Task LogoutAsync()
        {
            Settings.RemoveUserId();
            Settings.RemoveUserType();
            Settings.RemoveUserActive();
            Settings.RemoveUserMsg();
            Settings.RemoveAccessToken();

            return Task.FromResult(false);
        }

        public string GetCurrentUserId()
        {
            return Settings.UserId;
        }

        public string GetCurrentUserType()
        {
            return Settings.UserType;
        }
    }
}

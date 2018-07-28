using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MyPatchV3.UI.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string UserIdKey = "user_id_key";
        private static readonly string UserIdDefault = string.Empty;

        private const string UserTypeKey = "user_type_key";
        private static readonly string UserTypeDefault = string.Empty;

        private const string UserActiveKey = "user_active_key";
        private static readonly int UserActiveDefault = 0;

        private const string UserMsgKey = "user_msg_key";
        private static readonly string UserMsgDefault = string.Empty;

        private const string AccessTokenKey = "access_token_key";
        private static readonly string AccessTokenDefault = string.Empty;

        #endregion

        public static string UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserIdKey, UserIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserIdKey, value);
            }
        }

        public static string UserType
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserTypeKey, UserTypeDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserTypeKey, value);
            }
        }

        public static int UserActive
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserActiveKey, UserActiveDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserActiveKey, value);
            }
        }

        public static string UserMsg
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserMsgKey, UserMsgDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserMsgKey, value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(AccessTokenKey, AccessTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AccessTokenKey, value);
            }
        }

        public static void RemoveUserId()
        {
            AppSettings.Remove(UserIdKey);
        }

        public static void RemoveUserType()
        {
            AppSettings.Remove(UserTypeKey);
        }

        public static void RemoveUserActive()
        {
            AppSettings.Remove(UserActiveKey);
        }

        public static void RemoveUserMsg()
        {
            AppSettings.Remove(UserMsgKey);
        }

        public static void RemoveAccessToken()
        {
            AppSettings.Remove(AccessTokenKey);
        }
    }
}
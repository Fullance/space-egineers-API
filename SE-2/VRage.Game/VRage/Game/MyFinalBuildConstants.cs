namespace VRage.Game
{
    using System;
    using System.Text;
    using VRage.Utils;

    public class MyFinalBuildConstants
    {
        public static MyVersion APP_VERSION;
        public const short DEDICATED_SERVER_PORT = 0x6987;
        public const short DEDICATED_STEAM_AUTH_PORT = 0x223e;
        public const int IP_ADDRESS_ANY = 0;
        public const bool IS_CLOUD_GAMING = false;
        public const bool IS_DEBUG = false;
        public const bool IS_OFFICIAL = true;

        public static StringBuilder APP_VERSION_STRING =>
            APP_VERSION.FormattedText;

        public static StringBuilder APP_VERSION_STRING_DOTS =>
            APP_VERSION.FormattedTextFriendly;
    }
}


namespace VRage.Game
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyControllerData
    {
        public string DisplayName;
        public bool IsDead;
        public ulong SteamId;
        public int ControllerId;
        public string Model;
    }
}


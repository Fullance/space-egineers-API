namespace VRage.ModAPI
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Utils;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyTerminalControlComboBoxItem
    {
        public long Key;
        public MyStringId Value;
    }
}


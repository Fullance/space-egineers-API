namespace VRage.ModAPI
{
    using System;
    using System.Runtime.CompilerServices;
    using VRage.Utils;

    public class MyTerminalControlListBoxItem
    {
        public MyTerminalControlListBoxItem(MyStringId text, MyStringId tooltip, object userData)
        {
            this.Text = text;
            this.Tooltip = tooltip;
            this.UserData = userData;
        }

        public MyStringId Text { get; set; }

        public MyStringId Tooltip { get; set; }

        public object UserData { get; set; }
    }
}


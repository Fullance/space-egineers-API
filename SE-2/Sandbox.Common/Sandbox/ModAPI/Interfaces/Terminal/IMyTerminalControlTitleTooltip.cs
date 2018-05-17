namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using System;
    using VRage.Utils;

    public interface IMyTerminalControlTitleTooltip
    {
        MyStringId Title { get; set; }

        MyStringId Tooltip { get; set; }
    }
}


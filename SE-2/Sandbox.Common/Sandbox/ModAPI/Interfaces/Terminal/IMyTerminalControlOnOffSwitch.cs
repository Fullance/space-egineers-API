namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using Sandbox.ModAPI.Interfaces;
    using System;
    using VRage.Utils;

    public interface IMyTerminalControlOnOffSwitch : IMyTerminalControl, IMyTerminalValueControl<bool>, ITerminalProperty, IMyTerminalControlTitleTooltip
    {
        MyStringId OffText { get; set; }

        MyStringId OnText { get; set; }
    }
}


namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using System;

    public interface IMyTerminalControlButton : IMyTerminalControl, IMyTerminalControlTitleTooltip
    {
        Action<IMyTerminalBlock> Action { get; set; }
    }
}


namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using System;
    using VRage.Utils;

    public interface IMyTerminalControlLabel : IMyTerminalControl
    {
        MyStringId Label { get; set; }
    }
}


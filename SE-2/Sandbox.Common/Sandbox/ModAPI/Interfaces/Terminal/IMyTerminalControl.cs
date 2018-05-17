namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using System;

    public interface IMyTerminalControl
    {
        void RedrawControl();
        void UpdateVisual();

        Func<IMyTerminalBlock, bool> Enabled { get; set; }

        string Id { get; }

        bool SupportsMultipleBlocks { get; set; }

        Func<IMyTerminalBlock, bool> Visible { get; set; }
    }
}


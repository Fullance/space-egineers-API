namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using System;

    public interface IMyTerminalControlListbox : IMyTerminalControl, IMyTerminalControlTitleTooltip
    {
        Action<IMyTerminalBlock, List<MyTerminalControlListBoxItem>> ItemSelected { set; }

        Action<IMyTerminalBlock, List<MyTerminalControlListBoxItem>, List<MyTerminalControlListBoxItem>> ListContent { set; }

        bool Multiselect { get; set; }

        int VisibleRowsCount { get; set; }
    }
}


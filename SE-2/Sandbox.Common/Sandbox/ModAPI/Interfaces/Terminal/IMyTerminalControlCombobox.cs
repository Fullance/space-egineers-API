namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using Sandbox.ModAPI.Interfaces;
    using System;

    public interface IMyTerminalControlCombobox : IMyTerminalControl, IMyTerminalValueControl<long>, ITerminalProperty, IMyTerminalControlTitleTooltip
    {
        Action<List<MyTerminalControlComboBoxItem>> ComboBoxContent { get; set; }
    }
}


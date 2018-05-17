namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using Sandbox.ModAPI.Interfaces;

    public interface IMyTerminalControlTextbox : IMyTerminalControl, IMyTerminalValueControl<StringBuilder>, ITerminalProperty, IMyTerminalControlTitleTooltip
    {
    }
}


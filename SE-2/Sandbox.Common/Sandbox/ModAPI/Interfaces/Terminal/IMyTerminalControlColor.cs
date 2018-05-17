namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using Sandbox.ModAPI.Interfaces;

    public interface IMyTerminalControlColor : IMyTerminalControl, IMyTerminalValueControl<Color>, ITerminalProperty, IMyTerminalControlTitleTooltip
    {
    }
}


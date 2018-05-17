namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using Sandbox.ModAPI.Interfaces;

    public interface IMyTerminalControlProperty<TValue> : IMyTerminalControl, IMyTerminalValueControl<TValue>, ITerminalProperty
    {
    }
}


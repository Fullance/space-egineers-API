namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using Sandbox.ModAPI.Interfaces;
    using System;

    public interface IMyTerminalValueControl<TValue> : ITerminalProperty
    {
        Func<IMyTerminalBlock, TValue> Getter { get; set; }

        Action<IMyTerminalBlock, TValue> Setter { get; set; }
    }
}


namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using Sandbox.ModAPI.Interfaces;
    using System;

    public interface IMyTerminalControlSlider : IMyTerminalControl, IMyTerminalValueControl<float>, ITerminalProperty, IMyTerminalControlTitleTooltip
    {
        void SetDualLogLimits(Func<IMyTerminalBlock, float> minGetter, Func<IMyTerminalBlock, float> maxGetter, float centerBand);
        void SetDualLogLimits(float absMin, float absMax, float centerBand);
        void SetLimits(Func<IMyTerminalBlock, float> minGetter, Func<IMyTerminalBlock, float> maxGetter);
        void SetLimits(float min, float max);
        void SetLogLimits(Func<IMyTerminalBlock, float> minGetter, Func<IMyTerminalBlock, float> maxGetter);
        void SetLogLimits(float min, float max);

        Action<IMyTerminalBlock, StringBuilder> Writer { get; set; }
    }
}


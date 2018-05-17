namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    [Obsolete("Use IMyGasTank")]
    public interface IMyOxygenTank : IMyGasTank, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        [Obsolete("Use IMyGasTank.FilledRatio")]
        double GetOxygenLevel();
    }
}


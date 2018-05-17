namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    [Obsolete("Use IMyGasGenerator")]
    public interface IMyOxygenGenerator : IMyGasGenerator, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
    }
}


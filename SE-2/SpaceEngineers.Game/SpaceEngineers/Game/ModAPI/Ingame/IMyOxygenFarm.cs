namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyOxygenFarm : IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        float GetOutput();

        bool CanProduce { get; }
    }
}


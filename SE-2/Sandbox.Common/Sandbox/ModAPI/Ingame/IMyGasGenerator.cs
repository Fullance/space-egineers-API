namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyGasGenerator : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool AutoRefill { get; set; }

        bool UseConveyorSystem { get; set; }
    }
}


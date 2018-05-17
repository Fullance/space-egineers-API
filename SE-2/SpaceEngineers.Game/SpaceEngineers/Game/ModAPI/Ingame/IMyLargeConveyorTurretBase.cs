namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyLargeConveyorTurretBase : IMyLargeTurretBase, IMyUserControllableGun, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool UseConveyorSystem { get; }
    }
}


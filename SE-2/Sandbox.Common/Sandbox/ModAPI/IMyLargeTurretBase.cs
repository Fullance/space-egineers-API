namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.Game.ModAPI.Interfaces;
    using VRage.ModAPI;

    public interface IMyLargeTurretBase : Sandbox.ModAPI.IMyUserControllableGun, Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyLargeTurretBase, Sandbox.ModAPI.Ingame.IMyUserControllableGun, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity, IMyCameraController
    {
        void SetTarget(VRage.ModAPI.IMyEntity entity);
        void TrackTarget(VRage.ModAPI.IMyEntity entity);

        VRage.ModAPI.IMyEntity Target { get; }
    }
}


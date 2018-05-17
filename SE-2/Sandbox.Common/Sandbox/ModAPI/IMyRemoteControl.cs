namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.Game.ModAPI.Interfaces;
    using VRage.ModAPI;
    using VRageMath;

    public interface IMyRemoteControl : Sandbox.ModAPI.IMyShipController, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, IMyControllableEntity, Sandbox.ModAPI.Ingame.IMyRemoteControl, Sandbox.ModAPI.Ingame.IMyShipController, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        Vector3D GetFreeDestination(Vector3D originalDestination, float checkRadius, float shipRadius = 0f);
        bool GetNearestPlayer(out Vector3D playerPosition);
    }
}


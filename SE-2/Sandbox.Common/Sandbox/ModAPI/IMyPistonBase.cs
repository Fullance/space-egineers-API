namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyPistonBase : Sandbox.ModAPI.IMyMechanicalConnectionBlock, Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyPistonBase, Sandbox.ModAPI.Ingame.IMyMechanicalConnectionBlock, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        event Action<Sandbox.ModAPI.IMyPistonBase> AttachedEntityChanged;

        event Action<bool> LimitReached;

        void Attach(Sandbox.ModAPI.IMyPistonTop top, bool updateGroup = true);
    }
}


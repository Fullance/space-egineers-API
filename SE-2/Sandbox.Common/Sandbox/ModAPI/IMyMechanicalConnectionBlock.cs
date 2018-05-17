namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyMechanicalConnectionBlock : Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyMechanicalConnectionBlock, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        void Attach(Sandbox.ModAPI.IMyAttachableTopBlock top, bool updateGroup = true);

        Sandbox.ModAPI.IMyAttachableTopBlock Top { get; }

        VRage.Game.ModAPI.IMyCubeGrid TopGrid { get; }
    }
}


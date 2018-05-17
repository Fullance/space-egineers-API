namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.Game.ModAPI.Interfaces;
    using VRage.ModAPI;

    public interface IMyCockpit : Sandbox.ModAPI.IMyShipController, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, IMyControllableEntity, Sandbox.ModAPI.Ingame.IMyCockpit, Sandbox.ModAPI.Ingame.IMyShipController, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity, IMyCameraController
    {
        void AttachPilot(IMyCharacter pilot);
        void RemovePilot();

        float OxygenFilledRatio { get; set; }
    }
}


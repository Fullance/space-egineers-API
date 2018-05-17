namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyAssembler : Sandbox.ModAPI.IMyProductionBlock, Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyAssembler, Sandbox.ModAPI.Ingame.IMyProductionBlock, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        event Action<Sandbox.ModAPI.IMyAssembler> CurrentModeChanged;

        event Action<Sandbox.ModAPI.IMyAssembler> CurrentProgressChanged;

        event Action<Sandbox.ModAPI.IMyAssembler> CurrentStateChanged;
    }
}


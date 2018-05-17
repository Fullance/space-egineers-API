namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyGasGenerator : Sandbox.ModAPI.Ingame.IMyGasGenerator, Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        float PowerConsumptionMultiplier { get; set; }

        float ProductionCapacityMultiplier { get; set; }
    }
}


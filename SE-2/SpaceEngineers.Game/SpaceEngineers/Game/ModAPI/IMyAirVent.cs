namespace SpaceEngineers.Game.ModAPI
{
    using Sandbox.Game.EntityComponents;
    using Sandbox.ModAPI;
    using Sandbox.ModAPI.Ingame;
    using SpaceEngineers.Game.ModAPI.Ingame;
    using System;
    using VRage.Game.Components;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyAirVent : Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, SpaceEngineers.Game.ModAPI.Ingame.IMyAirVent, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        float GasInputPerSecond { get; }

        float GasOutputPerSecond { get; }

        MyResourceSinkInfo OxygenSinkInfo { get; set; }

        MyResourceSourceComponent SourceComp { get; set; }
    }
}


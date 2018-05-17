namespace SpaceEngineers.Game.ModAPI
{
    using Sandbox.ModAPI;
    using Sandbox.ModAPI.Ingame;
    using SpaceEngineers.Game.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyShipMergeBlock : Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, SpaceEngineers.Game.ModAPI.Ingame.IMyShipMergeBlock, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        event Action BeforeMerge;

        int GridCount { get; }

        SpaceEngineers.Game.ModAPI.IMyShipMergeBlock Other { get; }
    }
}


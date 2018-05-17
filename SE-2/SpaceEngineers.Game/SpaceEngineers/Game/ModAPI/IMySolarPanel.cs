namespace SpaceEngineers.Game.ModAPI
{
    using Sandbox.Game.EntityComponents;
    using Sandbox.ModAPI;
    using Sandbox.ModAPI.Ingame;
    using SpaceEngineers.Game.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMySolarPanel : Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, SpaceEngineers.Game.ModAPI.Ingame.IMySolarPanel, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        MyResourceSourceComponent SourceComp { get; set; }
    }
}


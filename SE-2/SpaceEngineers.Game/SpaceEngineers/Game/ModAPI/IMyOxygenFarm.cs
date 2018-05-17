namespace SpaceEngineers.Game.ModAPI
{
    using Sandbox.ModAPI;
    using Sandbox.ModAPI.Ingame;
    using SpaceEngineers.Game.ModAPI.Ingame;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyOxygenFarm : Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, SpaceEngineers.Game.ModAPI.Ingame.IMyOxygenFarm, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
    }
}


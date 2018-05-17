namespace SpaceEngineers.Game.ModAPI
{
    using Sandbox.Game.Entities;
    using Sandbox.ModAPI;
    using Sandbox.ModAPI.Ingame;
    using SpaceEngineers.Game.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyGravityGeneratorSphere : SpaceEngineers.Game.ModAPI.IMyGravityGeneratorBase, Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, IMyGravityProvider, SpaceEngineers.Game.ModAPI.Ingame.IMyGravityGeneratorSphere, SpaceEngineers.Game.ModAPI.Ingame.IMyGravityGeneratorBase, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        float Radius { get; set; }
    }
}


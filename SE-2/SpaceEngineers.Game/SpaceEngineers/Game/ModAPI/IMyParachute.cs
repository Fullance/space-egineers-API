namespace SpaceEngineers.Game.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using SpaceEngineers.Game.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyParachute : SpaceEngineers.Game.ModAPI.Ingame.IMyParachute, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        event Action<bool> DoorStateChanged;

        event Action<bool> ParachuteStateChanged;
    }
}


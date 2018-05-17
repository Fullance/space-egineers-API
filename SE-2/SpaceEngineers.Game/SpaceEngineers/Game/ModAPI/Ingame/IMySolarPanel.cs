namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMySolarPanel : IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        float CurrentOutput { get; }

        float MaxOutput { get; }
    }
}


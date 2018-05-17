namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyOreDetector : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool BroadcastUsingAntennas { get; set; }

        float Range { get; }
    }
}


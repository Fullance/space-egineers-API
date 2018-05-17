namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyWarhead : IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void Detonate();
        bool StartCountdown();
        bool StopCountdown();

        float DetonationTime { get; set; }

        bool IsArmed { get; set; }

        bool IsCountingDown { get; }
    }
}


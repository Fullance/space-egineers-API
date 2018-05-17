namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyTimerBlock : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void StartCountdown();
        void StopCountdown();
        void Trigger();

        bool IsCountingDown { get; }

        bool Silent { get; set; }

        float TriggerDelay { get; set; }
    }
}


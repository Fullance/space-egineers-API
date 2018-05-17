namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyGasTank : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void RefillBottles();

        bool AutoRefillBottles { get; set; }

        float Capacity { get; }

        double FilledRatio { get; }

        bool Stockpile { get; set; }
    }
}


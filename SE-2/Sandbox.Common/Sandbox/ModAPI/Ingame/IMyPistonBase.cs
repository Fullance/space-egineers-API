namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyPistonBase : IMyMechanicalConnectionBlock, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void Extend();
        void Retract();
        void Reverse();

        float CurrentPosition { get; }

        float HighestPosition { get; }

        float LowestPosition { get; }

        float MaxLimit { get; set; }

        float MaxVelocity { get; }

        float MinLimit { get; set; }

        PistonStatus Status { get; }

        float Velocity { get; set; }
    }
}


namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyMotorSuspension : IMyMotorBase, IMyMechanicalConnectionBlock, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool AirShockEnabled { get; set; }

        bool Brake { get; set; }

        [Obsolete]
        float Damping { get; }

        float Friction { get; set; }

        float Height { get; set; }

        bool InvertPropulsion { get; set; }

        bool InvertSteer { get; set; }

        float MaxSteerAngle { get; set; }

        float Power { get; set; }

        bool Propulsion { get; set; }

        float SteerAngle { get; }

        bool Steering { get; set; }

        [Obsolete]
        float SteerReturnSpeed { get; }

        [Obsolete]
        float SteerSpeed { get; }

        float Strength { get; set; }

        [Obsolete]
        float SuspensionTravel { get; }
    }
}


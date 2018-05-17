namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyMotorStator : IMyMotorBase, IMyMechanicalConnectionBlock, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        float Angle { get; }

        float BrakingTorque { get; set; }

        float Displacement { get; set; }

        float LowerLimitDeg { get; set; }

        float LowerLimitRad { get; set; }

        bool RotorLock { get; set; }

        float TargetVelocityRad { get; set; }

        float TargetVelocityRPM { get; set; }

        float Torque { get; set; }

        float UpperLimitDeg { get; set; }

        float UpperLimitRad { get; set; }
    }
}


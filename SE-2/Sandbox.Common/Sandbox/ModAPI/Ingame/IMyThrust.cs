namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyThrust : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        float CurrentThrust { get; }

        Vector3I GridThrustDirection { get; }

        float MaxEffectiveThrust { get; }

        float MaxThrust { get; }

        float ThrustOverride { get; set; }

        float ThrustOverridePercentage { get; set; }
    }
}


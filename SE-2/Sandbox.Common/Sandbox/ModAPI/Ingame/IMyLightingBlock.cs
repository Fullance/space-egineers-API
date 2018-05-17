namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyLightingBlock : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        float BlinkIntervalSeconds { get; set; }

        [Obsolete("Use BlinkLength instead.")]
        float BlinkLenght { get; }

        float BlinkLength { get; set; }

        float BlinkOffset { get; set; }

        VRageMath.Color Color { get; set; }

        float Falloff { get; set; }

        float Intensity { get; set; }

        float Radius { get; set; }

        [Obsolete("Use Radius")]
        float ReflectorRadius { get; }
    }
}


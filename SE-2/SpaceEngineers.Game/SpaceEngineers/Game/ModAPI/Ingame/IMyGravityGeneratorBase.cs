namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyGravityGeneratorBase : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        [Obsolete("Use GravityAcceleration.")]
        float Gravity { get; }

        float GravityAcceleration { get; set; }
    }
}


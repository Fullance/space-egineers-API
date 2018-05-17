namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyGyro : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool GyroOverride { get; set; }

        float GyroPower { get; set; }

        float Pitch { get; set; }

        float Roll { get; set; }

        float Yaw { get; set; }
    }
}


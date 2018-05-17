namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyLaserAntenna : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void Connect();
        void SetTargetCoords(string coords);
        bool TransmitMessage(string message);

        long AttachedProgrammableBlock { get; set; }

        [Obsolete("Check the Status property instead.")]
        bool IsOutsideLimits { get; }

        bool IsPermanent { get; set; }

        float Range { get; set; }

        bool RequireLoS { get; }

        MyLaserAntennaStatus Status { get; }

        Vector3D TargetCoords { get; }
    }
}


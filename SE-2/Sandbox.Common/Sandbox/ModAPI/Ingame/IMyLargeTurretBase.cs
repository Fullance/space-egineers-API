namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyLargeTurretBase : IMyUserControllableGun, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        MyDetectedEntityInfo GetTargetedEntity();
        void ResetTargetingToDefault();
        void SetTarget(Vector3D pos);
        void SyncAzimuth();
        void SyncElevation();
        void SyncEnableIdleRotation();
        void TrackTarget(Vector3D pos, Vector3 velocity);

        bool AIEnabled { get; }

        float Azimuth { get; set; }

        bool CanControl { get; }

        float Elevation { get; set; }

        bool EnableIdleRotation { get; set; }

        bool HasTarget { get; }

        bool IsAimed { get; }

        bool IsUnderControl { get; }

        float Range { get; }
    }
}


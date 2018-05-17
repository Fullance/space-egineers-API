namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyCameraBlock : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool CanScan(double distance);
        bool CanScan(Vector3D target);
        bool CanScan(double distance, Vector3D direction);
        MyDetectedEntityInfo Raycast(Vector3D targetPos);
        MyDetectedEntityInfo Raycast(double distance, Vector3D targetDirection);
        MyDetectedEntityInfo Raycast(double distance, float pitch = 0f, float yaw = 0f);
        int TimeUntilScan(double distance);

        double AvailableScanRange { get; }

        bool EnableRaycast { get; set; }

        bool IsActive { get; }

        float RaycastConeLimit { get; }

        double RaycastDistanceLimit { get; }
    }
}


namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyParachute : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void CloseDoor();
        Vector3D GetArtificialGravity();
        Vector3D GetNaturalGravity();
        Vector3D GetTotalGravity();
        Vector3D GetVelocity();
        void OpenDoor();
        void ToggleDoor();
        bool TryGetClosestPoint(out Vector3D? closestPoint);

        float Atmosphere { get; }

        float OpenRatio { get; }

        DoorStatus Status { get; }
    }
}


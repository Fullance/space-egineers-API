namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyShipController : IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        MyShipMass CalculateShipMass();
        Vector3D GetArtificialGravity();
        Vector3D GetNaturalGravity();
        double GetShipSpeed();
        MyShipVelocities GetShipVelocities();
        Vector3D GetTotalGravity();
        bool TryGetPlanetElevation(MyPlanetElevation detail, out double elevation);
        bool TryGetPlanetPosition(out Vector3D position);

        bool CanControlShip { get; }

        Vector3D CenterOfMass { get; }

        bool ControlThrusters { get; set; }

        bool ControlWheels { get; set; }

        bool DampenersOverride { get; set; }

        bool HandBrake { get; set; }

        bool HasWheels { get; }

        bool IsMainCockpit { get; set; }

        bool IsUnderControl { get; }

        Vector3 MoveIndicator { get; }

        float RollIndicator { get; }

        Vector2 RotationIndicator { get; }

        bool ShowHorizonIndicator { get; set; }
    }
}


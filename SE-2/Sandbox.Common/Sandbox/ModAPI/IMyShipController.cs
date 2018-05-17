namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.Game.ModAPI.Interfaces;
    using VRage.ModAPI;
    using VRageMath;

    public interface IMyShipController : Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyShipController, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity, IMyControllableEntity
    {
        bool HasFirstPersonCamera { get; }

        bool IsShooting { get; }

        IMyCharacter LastPilot { get; }

        Vector3 MoveIndicator { get; }

        IMyCharacter Pilot { get; }

        float RollIndicator { get; }

        Vector2 RotationIndicator { get; }
    }
}


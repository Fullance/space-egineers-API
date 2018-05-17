namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyJumpDrive : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        float CurrentStoredPower { get; }

        float MaxStoredPower { get; }

        MyJumpDriveStatus Status { get; }
    }
}


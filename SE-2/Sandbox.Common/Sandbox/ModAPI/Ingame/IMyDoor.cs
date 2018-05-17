namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyDoor : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void CloseDoor();
        void OpenDoor();
        void ToggleDoor();

        [Obsolete("Use the Status property instead")]
        bool Open { get; }

        float OpenRatio { get; }

        DoorStatus Status { get; }
    }
}


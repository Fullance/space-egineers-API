namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyLandingGear : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void Lock();
        void ResetAutoLock();
        void ToggleLock();
        void Unlock();

        bool AutoLock { get; set; }

        [Obsolete("Landing gear are not breakable anymore.")]
        bool IsBreakable { get; }

        bool IsLocked { get; }

        LandingGearMode LockMode { get; }
    }
}


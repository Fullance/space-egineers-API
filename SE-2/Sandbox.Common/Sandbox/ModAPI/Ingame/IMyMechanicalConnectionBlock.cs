namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyMechanicalConnectionBlock : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void Attach();
        void Detach();

        bool IsAttached { get; }

        [Obsolete("SafetyLock is no longer supported. This is property dummy property only, for backwards compatibility.")]
        bool IsLocked { get; }

        bool PendingAttachment { get; }

        [Obsolete("SafetyLock is no longer supported. This is property dummy property only, for backwards compatibility.")]
        bool SafetyLock { get; set; }

        [Obsolete("SafetyLock is no longer supported. This is property dummy property only, for backwards compatibility.")]
        float SafetyLockSpeed { get; set; }

        IMyAttachableTopBlock Top { get; }

        IMyCubeGrid TopGrid { get; }
    }
}


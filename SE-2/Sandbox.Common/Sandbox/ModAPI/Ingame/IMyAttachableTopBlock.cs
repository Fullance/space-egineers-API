namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyAttachableTopBlock : IMyCubeBlock, IMyEntity
    {
        IMyMechanicalConnectionBlock Base { get; }

        bool IsAttached { get; }
    }
}


namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyMotorRotor : Sandbox.ModAPI.IMyAttachableTopBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyMotorRotor, Sandbox.ModAPI.Ingame.IMyAttachableTopBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        Sandbox.ModAPI.IMyMotorBase Base { get; }

        [Obsolete("Use IMyAttachableTopBlock.Base")]
        Sandbox.ModAPI.IMyMotorBase Stator { get; }
    }
}


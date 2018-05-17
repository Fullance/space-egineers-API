namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyAttachableTopBlock : VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyAttachableTopBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        Sandbox.ModAPI.IMyMechanicalConnectionBlock Base { get; }
    }
}


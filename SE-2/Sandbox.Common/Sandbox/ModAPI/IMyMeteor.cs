namespace Sandbox.ModAPI
{
    using VRage.Game.ModAPI.Ingame;
    using VRage.Game.ModAPI.Interfaces;
    using VRage.ModAPI;

    public interface IMyMeteor : VRage.ModAPI.IMyEntity, VRage.Game.ModAPI.Ingame.IMyEntity, IMyDestroyableObject, IMyDecalProxy
    {
    }
}


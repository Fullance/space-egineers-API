namespace VRage.Game.ModAPI
{
    using VRage.Game.ModAPI.Ingame;
    using VRage.Game.ModAPI.Interfaces;
    using VRage.ModAPI;

    public interface IMyFloatingObject : VRage.ModAPI.IMyEntity, VRage.Game.ModAPI.Ingame.IMyEntity, IMyDestroyableObject
    {
    }
}


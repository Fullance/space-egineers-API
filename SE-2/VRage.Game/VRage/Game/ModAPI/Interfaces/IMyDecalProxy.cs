namespace VRage.Game.ModAPI.Interfaces
{
    using System;
    using VRage.Game.ModAPI;
    using VRage.Utils;

    public interface IMyDecalProxy
    {
        void AddDecals(ref MyHitInfo hitInfo, MyStringHash source, object customdata, IMyDecalHandler decalHandler, MyStringHash material);
    }
}


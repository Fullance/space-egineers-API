namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRageMath;

    public interface IMyGpsCollection
    {
        void AddGps(long identityId, IMyGps gps);
        void AddLocalGps(IMyGps gps);
        IMyGps Create(string name, string description, Vector3D coords, bool showOnHud, bool temporary = false);
        List<IMyGps> GetGpsList(long identityId);
        void GetGpsList(long identityId, List<IMyGps> list);
        void ModifyGps(long identityId, IMyGps gps);
        void RemoveGps(long identityId, int gpsHash);
        void RemoveGps(long identityId, IMyGps gps);
        void RemoveLocalGps(int gpsHash);
        void RemoveLocalGps(IMyGps gps);
        void SetShowOnHud(long identityId, int gpsHash, bool show);
        void SetShowOnHud(long identityId, IMyGps gps, bool show);
    }
}


namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRageMath;

    public interface IMyPrefabManager
    {
        bool IsPathClear(Vector3D from, Vector3D to);
        bool IsPathClear(Vector3D from, Vector3D to, double halfSize);
        void SpawnPrefab(List<IMyCubeGrid> resultList, string prefabName, Vector3D position, Vector3 forward, Vector3 up, Vector3 initialLinearVelocity = new Vector3(), Vector3 initialAngularVelocity = new Vector3(), string beaconName = null, SpawningOptions spawningOptions = 0, bool updateSync = false, Action callback = null);
        void SpawnPrefab(List<IMyCubeGrid> resultList, string prefabName, Vector3D position, Vector3 forward, Vector3 up, Vector3 initialLinearVelocity = new Vector3(), Vector3 initialAngularVelocity = new Vector3(), string beaconName = null, SpawningOptions spawningOptions = 0, long ownerId = 0L, bool updateSync = false, Action callback = null);
    }
}


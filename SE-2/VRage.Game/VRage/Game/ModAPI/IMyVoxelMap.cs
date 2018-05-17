namespace VRage.Game.ModAPI
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;
    using VRage.ObjectBuilders;
    using VRageMath;

    public interface IMyVoxelMap : IMyVoxelBase, VRage.ModAPI.IMyEntity, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        void ClampVoxelCoord(ref Vector3I voxelCoord);
        void Close();
        bool DoOverlapSphereTest(float sphereRadius, Vector3D spherePos);
        bool GetIntersectionWithSphere(ref BoundingSphereD sphere);
        MyObjectBuilder_EntityBase GetObjectBuilder(bool copy = false);
        float GetVoxelContentInBoundingBox(BoundingBoxD worldAabb, out float cellCount);
        Vector3I GetVoxelCoordinateFromMeters(Vector3D pos);
        void Init(MyObjectBuilder_EntityBase builder);
    }
}


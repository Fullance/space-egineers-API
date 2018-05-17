namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.ModAPI;
    using VRageMath;

    public interface IMyVoxelMaps
    {
        void Clear();
        IMyStorage CreateStorage(Vector3I size);
        IMyStorage CreateStorage(byte[] data);
        IMyVoxelMap CreateVoxelMap(string storageName, IMyStorage storage, Vector3D position, long voxelMapId);
        IMyVoxelMap CreateVoxelMapFromStorageName(string storageName, string prefabVoxelMapName, Vector3D position);
        void CutOutShape(IMyVoxelBase voxelMap, IMyVoxelShape voxelShape);
        bool Exist(IMyVoxelBase voxelMap);
        void FillInShape(IMyVoxelBase voxelMap, IMyVoxelShape voxelShape, byte materialIdx);
        IMyVoxelShapeBox GetBoxVoxelHand();
        IMyVoxelShapeCapsule GetCapsuleVoxelHand();
        void GetInstances(List<IMyVoxelBase> outInstances, Func<IMyVoxelBase, bool> collect = null);
        IMyVoxelBase GetOverlappingWithSphere(ref BoundingSphereD sphere);
        IMyVoxelShapeRamp GetRampVoxelHand();
        IMyVoxelShapeSphere GetSphereVoxelHand();
        IMyVoxelBase GetVoxelMapWhoseBoundingBoxIntersectsBox(ref BoundingBoxD boundingBox, IMyVoxelBase ignoreVoxelMap);
        void MakeCrater(IMyVoxelBase voxelMap, BoundingSphereD sphere, Vector3 direction, byte materialIdx);
        void PaintInShape(IMyVoxelBase voxelMap, IMyVoxelShape voxelShape, byte materialIdx);

        int VoxelMaterialCount { get; }
    }
}


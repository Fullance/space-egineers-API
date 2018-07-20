namespace VRage.Game.Voxels
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.ModAPI;
    using VRage.Voxels;
    using VRageMath;

    public interface IMyStorage : VRage.ModAPI.IMyStorage
    {
        event RangeChangedDelegate RangeChanged;

        void Close();
        VRage.Game.Voxels.IMyStorage Copy();
        void DebugDraw(ref MatrixD worldMatrix, MyVoxelDebugDrawMode mode);
        bool Intersect(ref LineD line);
        ContainmentType Intersect(ref BoundingBoxI box, int lod, bool exhaustiveContainmentCheck = true);
        StoragePin Pin();
        void Unpin();

        IMyStorageDataProvider DataProvider { get; }

        bool Shared { get; }

        uint StorageId { get; }
    }
}


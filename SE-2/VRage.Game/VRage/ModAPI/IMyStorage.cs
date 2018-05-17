namespace VRage.ModAPI
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Voxels;
    using VRageMath;

    public interface IMyStorage
    {
        bool Intersect(ref LineD line);
        ContainmentType Intersect(ref BoundingBox box, bool lazy);
        [Obsolete]
        void OverwriteAllMaterials(byte materialIndex);
        void PinAndExecute(Action action);
        void PinAndExecute(Action<IMyStorage> action);
        void ReadRange(MyStorageData target, MyStorageDataTypeFlags dataToRead, int lodIndex, Vector3I lodVoxelRangeMin, Vector3I lodVoxelRangeMax);
        void ReadRange(MyStorageData target, MyStorageDataTypeFlags dataToRead, int lodIndex, Vector3I lodVoxelRangeMin, Vector3I lodVoxelRangeMax, ref MyVoxelRequestFlags requestFlags);
        void Reset(MyStorageDataTypeFlags dataToReset);
        void Save(out byte[] outCompressedData);
        void WriteRange(MyStorageData source, MyStorageDataTypeFlags dataToWrite, Vector3I voxelRangeMin, Vector3I voxelRangeMax);

        bool Closed { get; }

        bool MarkedForClose { get; }

        Vector3I Size { get; }
    }
}


namespace VRage.Game.Voxels
{
    using System;
    using System.Runtime.CompilerServices;
    using VRage.Voxels;
    using VRageMath;

    public delegate void RangeChangedDelegate(Vector3I minVoxelChanged, Vector3I maxVoxelChanged, MyStorageDataTypeFlags changedData);
}


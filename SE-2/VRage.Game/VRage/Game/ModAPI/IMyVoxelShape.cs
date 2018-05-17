namespace VRage.Game.ModAPI
{
    using System;
    using VRageMath;

    public interface IMyVoxelShape
    {
        float GetIntersectionVolume(ref Vector3D voxelPosition);
        BoundingBoxD GetWorldBoundary();
        BoundingBoxD PeekWorldBoundary(ref Vector3D targetPosition);

        MatrixD Transform { get; set; }
    }
}


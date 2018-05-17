namespace VRage.ModAPI
{
    using System;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyVoxelBase : VRage.ModAPI.IMyEntity, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        bool IsBoxIntersectingBoundingBoxOfThisVoxelMap(ref BoundingBoxD boundingBox);

        Vector3D PositionLeftBottomCorner { get; }

        IMyStorage Storage { get; }

        string StorageName { get; }
    }
}


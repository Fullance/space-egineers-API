namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using VRageMath;

    public interface IMyModel
    {
        int GetDummies(IDictionary<string, IMyModelDummy> dummies);
        int GetTrianglesCount();
        int GetVerticesCount();

        string AssetName { get; }

        Vector3I[] BoneMapping { get; }

        VRageMath.BoundingBox BoundingBox { get; }

        Vector3 BoundingBoxSize { get; }

        Vector3 BoundingBoxSizeHalf { get; }

        VRageMath.BoundingSphere BoundingSphere { get; }

        int DataVersion { get; }

        float PatternScale { get; }

        float ScaleFactor { get; }

        int UniqueId { get; }
    }
}


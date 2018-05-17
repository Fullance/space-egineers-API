namespace VRage.Game.ModAPI
{
    using System;
    using VRageMath;

    public interface IMyVoxelShapeRamp : IMyVoxelShape
    {
        BoundingBoxD Boundaries { get; set; }

        Vector3D RampNormal { get; set; }

        double RampNormalW { get; set; }
    }
}


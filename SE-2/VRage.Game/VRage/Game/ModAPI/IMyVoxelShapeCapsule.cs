namespace VRage.Game.ModAPI
{
    using System;
    using VRageMath;

    public interface IMyVoxelShapeCapsule : IMyVoxelShape
    {
        Vector3D A { get; set; }

        Vector3D B { get; set; }

        float Radius { get; set; }
    }
}


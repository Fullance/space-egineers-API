namespace VRage.Game.ModAPI
{
    using System;
    using VRageMath;

    public interface IMyVoxelShapeSphere : IMyVoxelShape
    {
        Vector3D Center { get; set; }

        float Radius { get; set; }
    }
}


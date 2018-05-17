namespace VRage.Game.ModAPI
{
    using System;
    using VRageMath;

    public interface IMyVoxelShapeBox : IMyVoxelShape
    {
        BoundingBoxD Boundaries { get; set; }
    }
}


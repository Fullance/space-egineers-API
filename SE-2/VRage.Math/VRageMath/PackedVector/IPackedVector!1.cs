namespace VRageMath.PackedVector
{
    using System;

    public interface IPackedVector<TPacked> : IPackedVector
    {
        TPacked PackedValue { get; set; }
    }
}


namespace VRage.Game.Models
{
    using System;
    using System.Runtime.InteropServices;
    using VRageMath.PackedVector;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct MyCompressedBoneIndicesWeights
    {
        public HalfVector4 Weights;
        public Byte4 Indices;
    }
}


namespace VRage.Game.Models
{
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct VertexBoneIndicesWeights
    {
        public Vector4UByte Indices;
        public Vector4 Weights;
    }
}


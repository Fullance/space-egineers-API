namespace VRage.Game.Models
{
    using System;
    using System.Runtime.InteropServices;
    using VRageMath.PackedVector;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct MyCompressedVertexNormal
    {
        public HalfVector4 Position;
        public Byte4 Normal;
    }
}


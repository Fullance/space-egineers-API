namespace VRageMath
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public static class MyMortonCode3D
    {
        [Conditional("DEBUG")]
        private static void AssertRange(Vector3I value)
        {
        }

        public static void Decode(int code, out Vector3I value)
        {
            value.X = joinBits(code);
            value.Y = joinBits(code >> 1);
            value.Z = joinBits(code >> 2);
        }

        public static int Encode(ref Vector3I value) => 
            ((splitBits(value.X) | (splitBits(value.Y) << 1)) | (splitBits(value.Z) << 2));

        private static int joinBits(int x)
        {
            x &= 0x9249249;
            x = (x | (x >> 2)) & 0x30c30c3;
            x = (x | (x >> 4)) & 0x300f00f;
            x = (x | (x >> 8)) & 0x30000ff;
            x = (x | (x >> 0x10)) & 0x3ff;
            return x;
        }

        private static int splitBits(int x)
        {
            x = (x | (x << 0x10)) & 0x30000ff;
            x = (x | (x << 8)) & 0x300f00f;
            x = (x | (x << 4)) & 0x30c30c3;
            x = (x | (x << 2)) & 0x9249249;
            return x;
        }
    }
}


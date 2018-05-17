namespace VRageMath.PackedVector
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct NormalizedByte4 : IPackedVector<uint>, IPackedVector, IEquatable<NormalizedByte4>
    {
        private uint packedValue;
        public uint PackedValue
        {
            get => 
                this.packedValue;
            set
            {
                this.packedValue = value;
            }
        }
        public NormalizedByte4(float x, float y, float z, float w)
        {
            this.packedValue = PackHelper(x, y, z, w);
        }

        public NormalizedByte4(Vector4 vector)
        {
            this.packedValue = PackHelper(vector.X, vector.Y, vector.Z, vector.W);
        }

        public static bool operator ==(NormalizedByte4 a, NormalizedByte4 b) => 
            a.Equals(b);

        public static bool operator !=(NormalizedByte4 a, NormalizedByte4 b) => 
            !a.Equals(b);

        void IPackedVector.PackFromVector4(Vector4 vector)
        {
            this.packedValue = PackHelper(vector.X, vector.Y, vector.Z, vector.W);
        }

        private static uint PackHelper(float vectorX, float vectorY, float vectorZ, float vectorW) => 
            (((PackUtils.PackSNorm(0xff, vectorX) | (PackUtils.PackSNorm(0xff, vectorY) << 8)) | (PackUtils.PackSNorm(0xff, vectorZ) << 0x10)) | (PackUtils.PackSNorm(0xff, vectorW) << 0x18));

        public Vector4 ToVector4()
        {
            Vector4 vector;
            vector.X = PackUtils.UnpackSNorm(0xff, this.packedValue);
            vector.Y = PackUtils.UnpackSNorm(0xff, this.packedValue >> 8);
            vector.Z = PackUtils.UnpackSNorm(0xff, this.packedValue >> 0x10);
            vector.W = PackUtils.UnpackSNorm(0xff, this.packedValue >> 0x18);
            return vector;
        }

        public override string ToString() => 
            this.packedValue.ToString("X8", CultureInfo.InvariantCulture);

        public override int GetHashCode() => 
            this.packedValue.GetHashCode();

        public override bool Equals(object obj) => 
            ((obj is NormalizedByte4) && this.Equals((NormalizedByte4) obj));

        public bool Equals(NormalizedByte4 other) => 
            this.packedValue.Equals(other.packedValue);
    }
}


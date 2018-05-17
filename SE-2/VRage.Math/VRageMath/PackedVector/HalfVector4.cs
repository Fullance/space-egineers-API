namespace VRageMath.PackedVector
{
    using System;
    using System.Runtime.InteropServices;
    using Unsharper;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential), UnsharperDisableReflection]
    public struct HalfVector4 : IPackedVector<ulong>, IPackedVector, IEquatable<HalfVector4>
    {
        public ulong PackedValue;
        ulong IPackedVector<ulong>.PackedValue
        {
            get => 
                this.PackedValue;
            set
            {
                this.PackedValue = value;
            }
        }
        public HalfVector4(float x, float y, float z, float w)
        {
            this.PackedValue = PackHelper(x, y, z, w);
        }

        public HalfVector4(Vector4 vector)
        {
            this.PackedValue = PackHelper(vector.X, vector.Y, vector.Z, vector.W);
        }

        public HalfVector4(HalfVector3 vector3, ushort w)
        {
            this.PackedValue = vector3.ToHalfVector4().PackedValue | (w << 0x30);
        }

        public static bool operator ==(HalfVector4 a, HalfVector4 b) => 
            a.Equals(b);

        public static bool operator !=(HalfVector4 a, HalfVector4 b) => 
            !a.Equals(b);

        void IPackedVector.PackFromVector4(Vector4 vector)
        {
            this.PackedValue = PackHelper(vector.X, vector.Y, vector.Z, vector.W);
        }

        private static ulong PackHelper(float vectorX, float vectorY, float vectorZ, float vectorW) => 
            ((ulong) (((HalfUtils.Pack(vectorX) | (HalfUtils.Pack(vectorY) << 0x10)) | (HalfUtils.Pack(vectorZ) << 0x20)) | (HalfUtils.Pack(vectorW) << 0x30)));

        public Vector4 ToVector4()
        {
            Vector4 vector;
            vector.X = HalfUtils.Unpack((ushort) this.PackedValue);
            vector.Y = HalfUtils.Unpack((ushort) (this.PackedValue >> 0x10));
            vector.Z = HalfUtils.Unpack((ushort) (this.PackedValue >> 0x20));
            vector.W = HalfUtils.Unpack((ushort) (this.PackedValue >> 0x30));
            return vector;
        }

        public override string ToString() => 
            this.ToVector4().ToString();

        public override int GetHashCode() => 
            this.PackedValue.GetHashCode();

        public override bool Equals(object obj) => 
            ((obj is HalfVector4) && this.Equals((HalfVector4) obj));

        public bool Equals(HalfVector4 other) => 
            this.PackedValue.Equals(other.PackedValue);
    }
}


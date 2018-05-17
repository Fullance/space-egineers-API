namespace VRageMath.PackedVector
{
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct HalfVector2 : IPackedVector<uint>, IPackedVector, IEquatable<HalfVector2>
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
        public HalfVector2(float x, float y)
        {
            this.packedValue = PackHelper(x, y);
        }

        public HalfVector2(Vector2 vector)
        {
            this.packedValue = PackHelper(vector.X, vector.Y);
        }

        public static bool operator ==(HalfVector2 a, HalfVector2 b) => 
            a.Equals(b);

        public static bool operator !=(HalfVector2 a, HalfVector2 b) => 
            !a.Equals(b);

        void IPackedVector.PackFromVector4(Vector4 vector)
        {
            this.packedValue = PackHelper(vector.X, vector.Y);
        }

        private static uint PackHelper(float vectorX, float vectorY) => 
            ((uint) (HalfUtils.Pack(vectorX) | (HalfUtils.Pack(vectorY) << 0x10)));

        public Vector2 ToVector2()
        {
            Vector2 vector;
            vector.X = HalfUtils.Unpack((ushort) this.packedValue);
            vector.Y = HalfUtils.Unpack((ushort) (this.packedValue >> 0x10));
            return vector;
        }

        Vector4 IPackedVector.ToVector4()
        {
            Vector2 vector = this.ToVector2();
            return new Vector4(vector.X, vector.Y, 0f, 1f);
        }

        public override string ToString() => 
            this.ToVector2().ToString();

        public override int GetHashCode() => 
            this.packedValue.GetHashCode();

        public override bool Equals(object obj) => 
            ((obj is HalfVector2) && this.Equals((HalfVector2) obj));

        public bool Equals(HalfVector2 other) => 
            this.packedValue.Equals(other.packedValue);
    }
}


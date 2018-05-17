namespace VRageMath.PackedVector
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct Byte4 : IPackedVector<uint>, IPackedVector, IEquatable<Byte4>
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
        public Byte4(float x, float y, float z, float w)
        {
            this.packedValue = PackHelper(x, y, z, w);
        }

        public Byte4(Vector4 vector)
        {
            this.packedValue = PackHelper(vector.X, vector.Y, vector.Z, vector.W);
        }

        public Byte4(uint packedValue)
        {
            this.packedValue = packedValue;
        }

        public static bool operator ==(Byte4 a, Byte4 b) => 
            a.Equals(b);

        public static bool operator !=(Byte4 a, Byte4 b) => 
            !a.Equals(b);

        void IPackedVector.PackFromVector4(Vector4 vector)
        {
            this.packedValue = PackHelper(vector.X, vector.Y, vector.Z, vector.W);
        }

        private static uint PackHelper(float vectorX, float vectorY, float vectorZ, float vectorW) => 
            (((PackUtils.PackUnsigned(255f, vectorX) | (PackUtils.PackUnsigned(255f, vectorY) << 8)) | (PackUtils.PackUnsigned(255f, vectorZ) << 0x10)) | (PackUtils.PackUnsigned(255f, vectorW) << 0x18));

        public Vector4 ToVector4()
        {
            Vector4 vector;
            vector.X = this.packedValue & 0xff;
            vector.Y = (this.packedValue >> 8) & 0xff;
            vector.Z = (this.packedValue >> 0x10) & 0xff;
            vector.W = (this.packedValue >> 0x18) & 0xff;
            return vector;
        }

        public Vector4UByte ToVector4UByte()
        {
            Vector4UByte num;
            num.X = (byte) (this.packedValue & 0xff);
            num.Y = (byte) ((this.packedValue >> 8) & 0xff);
            num.Z = (byte) ((this.packedValue >> 0x10) & 0xff);
            num.W = (byte) ((this.packedValue >> 0x18) & 0xff);
            return num;
        }

        public override string ToString() => 
            this.packedValue.ToString("X8", CultureInfo.InvariantCulture);

        public override int GetHashCode() => 
            this.packedValue.GetHashCode();

        public override bool Equals(object obj) => 
            ((obj is Byte4) && this.Equals((Byte4) obj));

        public bool Equals(Byte4 other) => 
            this.packedValue.Equals(other.packedValue);
    }
}


namespace VRageMath.PackedVector
{
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct HalfVector3
    {
        public ushort X;
        public ushort Y;
        public ushort Z;
        public HalfVector3(float x, float y, float z)
        {
            this.X = HalfUtils.Pack(x);
            this.Y = HalfUtils.Pack(y);
            this.Z = HalfUtils.Pack(z);
        }

        public HalfVector3(Vector3 vector) : this(vector.X, vector.Y, vector.Z)
        {
        }

        public Vector3 ToVector3()
        {
            Vector3 vector;
            vector.X = HalfUtils.Unpack(this.X);
            vector.Y = HalfUtils.Unpack(this.Y);
            vector.Z = HalfUtils.Unpack(this.Z);
            return vector;
        }

        public HalfVector4 ToHalfVector4()
        {
            HalfVector4 vector;
            vector.PackedValue = (ulong) ((this.X | (this.Y << 0x10)) | (this.Z << 0x20));
            return vector;
        }

        public static implicit operator HalfVector3(Vector3 v) => 
            new HalfVector3(v);

        public static implicit operator Vector3(HalfVector3 v) => 
            v.ToVector3();

        public override string ToString() => 
            this.ToVector3().ToString();
    }
}


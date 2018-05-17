namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector3Ushort
    {
        [ProtoMember(10)]
        public ushort X;
        [ProtoMember(12)]
        public ushort Y;
        [ProtoMember(14)]
        public ushort Z;
        public Vector3Ushort(ushort x, ushort y, ushort z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString() => 
            string.Concat(new object[] { this.X, ", ", this.Y, ", ", this.Z });

        public static Vector3Ushort operator *(Vector3Ushort v, ushort t) => 
            new Vector3Ushort((ushort) (t * v.X), (ushort) (t * v.Y), (ushort) (t * v.Z));

        public static Vector3 operator *(Vector3 vector, Vector3Ushort ushortVector) => 
            ((Vector3) (ushortVector * vector));

        public static Vector3 operator *(Vector3Ushort ushortVector, Vector3 vector) => 
            new Vector3(ushortVector.X * vector.X, ushortVector.Y * vector.Y, ushortVector.Z * vector.Z);

        public static explicit operator Vector3(Vector3Ushort v) => 
            new Vector3((float) v.X, (float) v.Y, (float) v.Z);
    }
}


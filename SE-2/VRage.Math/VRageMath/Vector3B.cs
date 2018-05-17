namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector3B
    {
        [ProtoMember(12)]
        public sbyte X;
        [ProtoMember(14)]
        public sbyte Y;
        [ProtoMember(0x10)]
        public sbyte Z;
        public static readonly Vector3B Zero;
        public static Vector3B Up;
        public static Vector3B Down;
        public static Vector3B Right;
        public static Vector3B Left;
        public static Vector3B Forward;
        public static Vector3B Backward;
        public Vector3B(sbyte x, sbyte y, sbyte z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3B(Vector3I vec)
        {
            this.X = (sbyte) vec.X;
            this.Y = (sbyte) vec.Y;
            this.Z = (sbyte) vec.Z;
        }

        public override string ToString() => 
            string.Concat(new object[] { this.X, ", ", this.Y, ", ", this.Z });

        public override int GetHashCode() => 
            (((((byte) this.Z) << 0x10) | (((byte) this.Y) << 8)) | ((byte) this.X));

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Vector3B? nullable = obj as Vector3B?;
                if (nullable.HasValue)
                {
                    return (this == nullable.Value);
                }
            }
            return false;
        }

        public static Vector3 operator *(Vector3 vector, Vector3B shortVector) => 
            ((Vector3) (shortVector * vector));

        public static Vector3 operator *(Vector3B shortVector, Vector3 vector) => 
            new Vector3(shortVector.X * vector.X, shortVector.Y * vector.Y, shortVector.Z * vector.Z);

        public static implicit operator Vector3I(Vector3B vec) => 
            new Vector3I(vec.X, vec.Y, vec.Z);

        public static Vector3B Round(Vector3 vec) => 
            new Vector3B((sbyte) Math.Round((double) vec.X), (sbyte) Math.Round((double) vec.Y), (sbyte) Math.Round((double) vec.Z));

        public static bool operator ==(Vector3B a, Vector3B b) => 
            (((a.X == b.X) && (a.Y == b.Y)) && (a.Z == b.Z));

        public static bool operator !=(Vector3B a, Vector3B b) => 
            !(a == b);

        public static Vector3B operator -(Vector3B me) => 
            new Vector3B(-me.X, -me.Y, -me.Z);

        public static Vector3B Fit(Vector3 vec, float range) => 
            Round((Vector3) ((vec / range) * 128f));

        static Vector3B()
        {
            Zero = new Vector3B();
            Up = new Vector3B(0, 1, 0);
            Down = new Vector3B(0, -1, 0);
            Right = new Vector3B(1, 0, 0);
            Left = new Vector3B(-1, 0, 0);
            Forward = new Vector3B(0, 0, -1);
            Backward = new Vector3B(0, 0, 1);
        }
    }
}


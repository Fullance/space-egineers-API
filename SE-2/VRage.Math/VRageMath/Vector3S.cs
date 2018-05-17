namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector3S
    {
        [ProtoMember(10)]
        public short X;
        [ProtoMember(12)]
        public short Y;
        [ProtoMember(14)]
        public short Z;
        public static Vector3S Up;
        public static Vector3S Down;
        public static Vector3S Right;
        public static Vector3S Left;
        public static Vector3S Forward;
        public static Vector3S Backward;
        public Vector3S(Vector3I vec) : this(ref vec)
        {
        }

        public Vector3S(ref Vector3I vec)
        {
            this.X = (short) vec.X;
            this.Y = (short) vec.Y;
            this.Z = (short) vec.Z;
        }

        public Vector3S(short x, short y, short z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3S(float x, float y, float z)
        {
            this.X = (short) x;
            this.Y = (short) y;
            this.Z = (short) z;
        }

        public override string ToString() => 
            string.Concat(new object[] { this.X, ", ", this.Y, ", ", this.Z });

        public override int GetHashCode() => 
            ((((this.X * 0x18d) ^ this.Y) * 0x18d) ^ this.Z);

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Vector3S? nullable = obj as Vector3S?;
                if (nullable.HasValue)
                {
                    return (this == nullable.Value);
                }
            }
            return false;
        }

        public static Vector3S operator *(Vector3S v, short t) => 
            new Vector3S((short) (t * v.X), (short) (t * v.Y), (short) (t * v.Z));

        public static Vector3 operator *(Vector3S v, float t) => 
            new Vector3(t * v.X, t * v.Y, t * v.Z);

        public static Vector3 operator *(Vector3 vector, Vector3S shortVector) => 
            ((Vector3) (shortVector * vector));

        public static Vector3 operator *(Vector3S shortVector, Vector3 vector) => 
            new Vector3(shortVector.X * vector.X, shortVector.Y * vector.Y, shortVector.Z * vector.Z);

        public static bool operator ==(Vector3S v1, Vector3S v2) => 
            (((v1.X == v2.X) && (v1.Y == v2.Y)) && (v1.Z == v2.Z));

        public static bool operator !=(Vector3S v1, Vector3S v2)
        {
            if ((v1.X == v2.X) && (v1.Y == v2.Y))
            {
                return (v1.Z != v2.Z);
            }
            return true;
        }

        public static Vector3S Round(Vector3 v) => 
            new Vector3S((short) Math.Round((double) v.X), (short) Math.Round((double) v.Y), (short) Math.Round((double) v.Z));

        public static implicit operator Vector3I(Vector3S me) => 
            new Vector3I(me.X, me.Y, me.Z);

        public static Vector3I operator -(Vector3S op1, Vector3B op2) => 
            new Vector3I(op1.X - op2.X, op1.Y - op2.Y, op1.Z - op2.Z);

        static Vector3S()
        {
            Up = new Vector3S(0, 1, 0);
            Down = new Vector3S(0, -1, 0);
            Right = new Vector3S(1, 0, 0);
            Left = new Vector3S(-1, 0, 0);
            Forward = new Vector3S(0, 0, -1);
            Backward = new Vector3S(0, 0, 1);
        }
    }
}


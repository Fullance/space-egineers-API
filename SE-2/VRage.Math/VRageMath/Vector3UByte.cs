namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector3UByte
    {
        public static readonly EqualityComparer Comparer;
        public static Vector3UByte Zero;
        [ProtoMember(0x25)]
        public byte X;
        [ProtoMember(0x27)]
        public byte Y;
        [ProtoMember(0x29)]
        public byte Z;
        private static Vector3 m_clampBoundary;
        public Vector3UByte(byte x, byte y, byte z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3UByte(Vector3I vec)
        {
            this.X = (byte) vec.X;
            this.Y = (byte) vec.Y;
            this.Z = (byte) vec.Z;
        }

        public override string ToString() => 
            string.Concat(new object[] { this.X, ", ", this.Y, ", ", this.Z });

        public override int GetHashCode() => 
            (((this.Z << 0x10) | (this.Y << 8)) | this.X);

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Vector3UByte? nullable = obj as Vector3UByte?;
                if (nullable.HasValue)
                {
                    return (this == nullable.Value);
                }
            }
            return false;
        }

        public static bool operator ==(Vector3UByte a, Vector3UByte b) => 
            (((a.X == b.X) && (a.Y == b.Y)) && (a.Z == b.Z));

        public static bool operator !=(Vector3UByte a, Vector3UByte b)
        {
            if ((a.X == b.X) && (a.Y == b.Y))
            {
                return (a.Z != b.Z);
            }
            return true;
        }

        public static Vector3UByte Round(Vector3 vec) => 
            new Vector3UByte((byte) Math.Round((double) vec.X), (byte) Math.Round((double) vec.Y), (byte) Math.Round((double) vec.Z));

        public static Vector3UByte Floor(Vector3 vec) => 
            new Vector3UByte((byte) Math.Floor((double) vec.X), (byte) Math.Floor((double) vec.Y), (byte) Math.Floor((double) vec.Z));

        public static implicit operator Vector3I(Vector3UByte vec) => 
            new Vector3I(vec.X, vec.Y, vec.Z);

        public int LengthSquared() => 
            (((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z));

        public static bool IsMiddle(Vector3UByte vec) => 
            (((vec.X == 0x7f) && (vec.Y == 0x7f)) && (vec.Z == 0x7f));

        public static Vector3UByte Normalize(Vector3 vec, float range)
        {
            Vector3 vector = (Vector3) ((((vec / range) / 2f) + new Vector3(0.5f)) * 255f);
            Vector3.Clamp(ref vector, ref Vector3.Zero, ref m_clampBoundary, out vector);
            return new Vector3UByte((byte) vector.X, (byte) vector.Y, (byte) vector.Z);
        }

        public static Vector3 Denormalize(Vector3UByte vec, float range)
        {
            float num = 0.001960784f;
            return (Vector3) ((((new Vector3((float) vec.X, (float) vec.Y, (float) vec.Z) / 255f) - new Vector3(0.5f - num)) * 2f) * range);
        }

        static Vector3UByte()
        {
            Comparer = new EqualityComparer();
            Zero = new Vector3UByte(0, 0, 0);
            m_clampBoundary = new Vector3(255f);
        }
        public class EqualityComparer : IEqualityComparer<Vector3UByte>, IComparer<Vector3UByte>
        {
            public int Compare(Vector3UByte a, Vector3UByte b)
            {
                int num = a.X - b.X;
                int num2 = a.Y - b.Y;
                int num3 = a.Z - b.Z;
                if (num != 0)
                {
                    return num;
                }
                if (num2 == 0)
                {
                    return num3;
                }
                return num2;
            }

            public bool Equals(Vector3UByte x, Vector3UByte y) => 
                (((x.X == y.X) & (x.Y == y.Y)) & (x.Z == y.Z));

            public int GetHashCode(Vector3UByte obj) => 
                ((((obj.X * 0x18d) ^ obj.Y) * 0x18d) ^ obj.Z);
        }
    }
}


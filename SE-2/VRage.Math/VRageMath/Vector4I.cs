namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using VRageMath.PackedVector;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector4I : IComparable<Vector4I>
    {
        [ProtoMember(11)]
        public int X;
        [ProtoMember(13)]
        public int Y;
        [ProtoMember(15)]
        public int Z;
        [ProtoMember(0x11)]
        public int W;
        public static readonly EqualityComparer Comparer;
        public Vector4I(int x, int y, int z, int w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Vector4I(Vector3I xyz, int w)
        {
            this.X = xyz.X;
            this.Y = xyz.Y;
            this.Z = xyz.Z;
            this.W = w;
        }

        public static explicit operator Byte4(Vector4I xyzw) => 
            new Byte4((float) xyzw.X, (float) xyzw.Y, (float) xyzw.Z, (float) xyzw.W);

        public int CompareTo(Vector4I other)
        {
            int num = this.X - other.X;
            int num2 = this.Y - other.Y;
            int num3 = this.Z - other.Z;
            int num4 = this.W - other.W;
            if (num != 0)
            {
                return num;
            }
            if (num2 != 0)
            {
                return num2;
            }
            if (num3 == 0)
            {
                return num4;
            }
            return num3;
        }

        public override string ToString() => 
            string.Concat(new object[] { this.X, ", ", this.Y, ", ", this.Z, ", ", this.W });

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.X;

                    case 1:
                        return this.Y;

                    case 2:
                        return this.Z;

                    case 3:
                        return this.W;
                }
                throw new Exception("Index out of bounds");
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.X = value;
                        return;

                    case 1:
                        this.Y = value;
                        return;

                    case 2:
                        this.Z = value;
                        return;

                    case 3:
                        this.W = value;
                        return;
                }
                throw new Exception("Index out of bounds");
            }
        }
        static Vector4I()
        {
            Comparer = new EqualityComparer();
        }
        public class EqualityComparer : IEqualityComparer<Vector4I>, IComparer<Vector4I>
        {
            public int Compare(Vector4I x, Vector4I y) => 
                x.CompareTo(y);

            public bool Equals(Vector4I x, Vector4I y) => 
                ((((x.X == y.X) && (x.Y == y.Y)) && (x.Z == y.Z)) && (x.W == y.W));

            public int GetHashCode(Vector4I obj) => 
                ((((((obj.X * 0x18d) ^ obj.Y) * 0x18d) ^ obj.Z) * 0x18d) ^ obj.W);
        }
    }
}


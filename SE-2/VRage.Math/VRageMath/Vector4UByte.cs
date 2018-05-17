namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector4UByte
    {
        [ProtoMember(11)]
        public byte X;
        [ProtoMember(13)]
        public byte Y;
        [ProtoMember(15)]
        public byte Z;
        [ProtoMember(0x11)]
        public byte W;
        public Vector4UByte(byte x, byte y, byte z, byte w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public override string ToString() => 
            string.Concat(new object[] { this.X, ", ", this.Y, ", ", this.Z, ", ", this.W });

        public static Vector4UByte Round(Vector3 vec) => 
            Round(new Vector4(vec.X, vec.Y, vec.Z, 0f));

        public static Vector4UByte Round(Vector4 vec) => 
            new Vector4UByte((byte) Math.Round((double) vec.X), (byte) Math.Round((double) vec.Y), (byte) Math.Round((double) vec.Z), 0);

        public static Vector4UByte Normalize(Vector3 vec, float range) => 
            Round((Vector3) ((((vec / range) / 2f) + new Vector3(0.5f)) * 255f));

        public byte this[int index]
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
    }
}


namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyUShort4
    {
        public ushort X;
        public ushort Y;
        public ushort Z;
        public ushort W;
        public MyUShort4(uint x, uint y, uint z, uint w)
        {
            this.X = (ushort) x;
            this.Y = (ushort) y;
            this.Z = (ushort) z;
            this.W = (ushort) w;
        }

        public static unsafe explicit operator ulong(MyUShort4 val) => 
            *(((ulong*) &val));

        public static unsafe explicit operator MyUShort4(ulong val) => 
            ((MyUShort4) ((IntPtr) &val));
    }
}


namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyShort4
    {
        public short X;
        public short Y;
        public short Z;
        public short W;
        public static unsafe explicit operator ulong(MyShort4 val) => 
            *(((ulong*) &val));

        public static unsafe explicit operator MyShort4(ulong val) => 
            ((MyShort4) ((IntPtr) &val));
    }
}


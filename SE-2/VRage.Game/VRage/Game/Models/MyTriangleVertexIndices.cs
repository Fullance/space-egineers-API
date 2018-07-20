namespace VRage.Game.Models
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyTriangleVertexIndices
    {
        public int I0;
        public int I1;
        public int I2;
        public MyTriangleVertexIndices(int i0, int i1, int i2)
        {
            this.I0 = i0;
            this.I1 = i1;
            this.I2 = i2;
        }

        public void Set(int i0, int i1, int i2)
        {
            this.I0 = i0;
            this.I1 = i1;
            this.I2 = i2;
        }
    }
}


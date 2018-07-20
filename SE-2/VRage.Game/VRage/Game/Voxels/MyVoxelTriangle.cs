namespace VRage.Game.Voxels
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct MyVoxelTriangle
    {
        public ushort V0;
        public ushort V1;
        public ushort V2;
        public MyVoxelTriangle(ushort v0, ushort v1, ushort v2)
        {
            this.V0 = v0;
            this.V1 = v1;
            this.V2 = v2;
        }

        public ushort this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return this.V0;

                    case 1:
                        return this.V1;

                    case 2:
                        return this.V2;
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                switch (i)
                {
                    case 0:
                        this.V0 = value;
                        return;

                    case 1:
                        this.V1 = value;
                        return;

                    case 2:
                        this.V2 = value;
                        return;
                }
                throw new IndexOutOfRangeException();
            }
        }
        public override string ToString() => 
            string.Concat(new object[] { "{", this.V0, ", ", this.V1, ", ", this.V2, "}" });
    }
}


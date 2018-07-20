namespace VRage.Game.Voxels
{
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyVoxelVertex
    {
        public Vector3 Position;
        public Vector3 Normal;
        public int Material;
        public Vector3I Cell;
        public uint ColorShiftHSV;
    }
}


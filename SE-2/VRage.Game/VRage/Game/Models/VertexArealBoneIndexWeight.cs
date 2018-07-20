namespace VRage.Game.Models
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct VertexArealBoneIndexWeight
    {
        public byte Index;
        public float Weight;
    }
}


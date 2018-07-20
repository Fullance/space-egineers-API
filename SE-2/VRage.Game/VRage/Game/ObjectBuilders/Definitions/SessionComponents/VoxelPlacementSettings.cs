namespace VRage.Game.ObjectBuilders.Definitions.SessionComponents
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct VoxelPlacementSettings
    {
        public VoxelPlacementMode PlacementMode;
        public float MaxAllowed;
        public float MinAllowed;
    }
}


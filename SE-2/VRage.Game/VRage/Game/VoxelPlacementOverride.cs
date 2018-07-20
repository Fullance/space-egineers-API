namespace VRage.Game
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ObjectBuilders.Definitions.SessionComponents;

    [StructLayout(LayoutKind.Sequential)]
    public struct VoxelPlacementOverride
    {
        public VoxelPlacementSettings StaticMode;
        public VoxelPlacementSettings DynamicMode;
    }
}


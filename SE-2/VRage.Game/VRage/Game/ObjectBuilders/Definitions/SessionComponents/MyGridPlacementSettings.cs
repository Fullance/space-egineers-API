namespace VRage.Game.ObjectBuilders.Definitions.SessionComponents
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyGridPlacementSettings
    {
        public VRage.Game.ObjectBuilders.Definitions.SessionComponents.SnapMode SnapMode;
        public float SearchHalfExtentsDeltaRatio;
        public float SearchHalfExtentsDeltaAbsolute;
        public VoxelPlacementSettings? VoxelPlacement;
        public bool CanAnchorToStaticGrid;
        public bool EnablePreciseRotationWhenSnapped;
    }
}


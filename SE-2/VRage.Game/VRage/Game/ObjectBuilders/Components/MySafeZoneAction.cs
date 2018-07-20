namespace VRage.Game.ObjectBuilders.Components
{
    using System;

    [Flags]
    public enum MySafeZoneAction
    {
        All = 0x7f,
        Building = 0x40,
        Damage = 1,
        Drilling = 4,
        Grinding = 0x10,
        Shooting = 2,
        VoxelHand = 0x20,
        Welding = 8
    }
}


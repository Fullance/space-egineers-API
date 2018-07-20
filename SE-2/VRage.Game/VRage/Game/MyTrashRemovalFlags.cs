namespace VRage.Game
{
    using System;

    [Flags]
    public enum MyTrashRemovalFlags
    {
        Accelerating = 0x10,
        Controlled = 0x40,
        Default = 0x61a,
        DistanceFromPlayer = 0x400,
        Fixed = 1,
        Linear = 8,
        None = 0,
        Powered = 0x20,
        Stationary = 2,
        WithBlockCount = 0x200,
        WithMedBay = 0x100,
        WithProduction = 0x80
    }
}


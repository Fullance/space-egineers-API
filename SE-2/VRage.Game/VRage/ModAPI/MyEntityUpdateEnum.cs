namespace VRage.ModAPI
{
    using System;

    [Flags]
    public enum MyEntityUpdateEnum
    {
        BEFORE_NEXT_FRAME = 8,
        EACH_100TH_FRAME = 4,
        EACH_10TH_FRAME = 2,
        EACH_FRAME = 1,
        NONE = 0,
        SIMULATE = 0x10
    }
}


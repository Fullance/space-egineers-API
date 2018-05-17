namespace Sandbox.ModAPI.Ingame
{
    using System;

    [Flags]
    public enum MyTransmitTarget
    {
        Ally = 2,
        Default = 3,
        Enemy = 8,
        Everyone = 15,
        Neutral = 4,
        None = 0,
        Owned = 1
    }
}


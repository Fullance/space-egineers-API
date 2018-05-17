namespace Sandbox.ModAPI.Ingame
{
    using System;

    [Flags]
    public enum UpdateType
    {
        Antenna = 4,
        Mod = 8,
        None = 0,
        Once = 0x100,
        Script = 0x10,
        Terminal = 1,
        Trigger = 2,
        Update1 = 0x20,
        Update10 = 0x40,
        Update100 = 0x80
    }
}


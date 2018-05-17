namespace Sandbox.ModAPI.Ingame
{
    using System;

    [Flags]
    public enum UpdateFrequency : byte
    {
        None = 0,
        Once = 8,
        Update1 = 1,
        Update10 = 2,
        Update100 = 4
    }
}


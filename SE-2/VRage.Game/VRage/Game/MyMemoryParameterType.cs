namespace VRage.Game
{
    using System;

    [Flags]
    public enum MyMemoryParameterType : byte
    {
        IN = 1,
        IN_OUT = 3,
        OUT = 2,
        PARAMETER = 4
    }
}


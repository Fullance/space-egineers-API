namespace VRage.Game.ModAPI
{
    using System;

    [Flags]
    public enum SpawningOptions
    {
        DisableDampeners = 8,
        DisableSave = 0x40,
        None = 0,
        RotateFirstCockpitTowardsDirection = 2,
        SetNeutralOwner = 0x10,
        SpawnRandomCargo = 4,
        TurnOffReactors = 0x20,
        UseGridOrigin = 0x80
    }
}


namespace VRage.ModAPI
{
    using System;

    [Flags]
    public enum EntityFlags
    {
        Default = 0x10114a,
        DrawOutsideViewDistance = 0x40000,
        FastCastShadowResolve = 0x80,
        InvalidateOnMove = 0x1000,
        IsGamePrunningStructureObject = 0x80000,
        IsNotGamePrunningStructureObject = 0x200000,
        Near = 0x10,
        NeedsDraw = 0x800,
        NeedsDrawFromParent = 0x4000,
        NeedsResolveCastShadow = 0x40,
        NeedsSimulate = 0x400000,
        NeedsUpdate = 0x20,
        NeedsUpdate10 = 0x200,
        NeedsUpdate100 = 0x400,
        NeedsUpdateBeforeNextFrame = 0x20000,
        NeedsWorldMatrix = 0x100000,
        None = 1,
        Save = 8,
        ShadowBoxLod = 0x8000,
        SkipIfTooSmall = 0x100,
        Sync = 0x2000,
        Transparent = 0x10000,
        Visible = 2
    }
}


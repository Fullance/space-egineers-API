namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyAssembler : IMyProductionBlock, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool CooperativeMode { get; set; }

        float CurrentProgress { get; }

        [Obsolete("Use the Mode property")]
        bool DisassembleEnabled { get; }

        MyAssemblerMode Mode { get; set; }

        bool Repeating { get; set; }
    }
}


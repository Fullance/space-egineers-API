namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyBatteryBlock : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        float CurrentInput { get; }

        float CurrentOutput { get; }

        float CurrentStoredPower { get; }

        bool HasCapacityRemaining { get; }

        bool IsCharging { get; }

        float MaxInput { get; }

        float MaxOutput { get; }

        float MaxStoredPower { get; }

        bool OnlyDischarge { get; set; }

        bool OnlyRecharge { get; set; }

        bool SemiautoEnabled { get; set; }
    }
}


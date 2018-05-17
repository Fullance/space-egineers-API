namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyReactor : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        float CurrentOutput { get; }

        float MaxOutput { get; }

        bool UseConveyorSystem { get; set; }
    }
}


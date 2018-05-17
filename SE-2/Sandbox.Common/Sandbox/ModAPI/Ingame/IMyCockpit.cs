namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyCockpit : IMyShipController, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool IsMainCockpit { get; set; }

        float OxygenCapacity { get; }

        float OxygenFilledRatio { get; }
    }
}


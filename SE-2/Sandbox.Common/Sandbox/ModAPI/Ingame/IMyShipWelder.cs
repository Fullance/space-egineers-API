namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyShipWelder : IMyShipToolBase, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool HelpOthers { get; set; }
    }
}


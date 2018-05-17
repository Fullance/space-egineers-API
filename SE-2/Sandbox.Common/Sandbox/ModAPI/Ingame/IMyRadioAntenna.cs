namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyRadioAntenna : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool TransmitMessage(string message, MyTransmitTarget target = 3);

        long AttachedProgrammableBlock { get; set; }

        bool EnableBroadcasting { get; set; }

        bool IgnoreAlliedBroadcast { get; set; }

        bool IgnoreOtherBroadcast { get; set; }

        bool IsBroadcasting { get; }

        float Radius { get; set; }

        bool ShowShipName { get; set; }
    }
}


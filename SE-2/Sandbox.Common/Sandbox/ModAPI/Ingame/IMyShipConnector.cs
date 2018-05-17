namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyShipConnector : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void Connect();
        void Disconnect();
        void ToggleConnect();

        bool CollectAll { get; set; }

        [Obsolete("Use the Status property")]
        bool IsConnected { get; }

        [Obsolete("Use the Status property")]
        bool IsLocked { get; }

        IMyShipConnector OtherConnector { get; }

        float PullStrength { get; set; }

        MyShipConnectorStatus Status { get; }

        bool ThrowOut { get; set; }
    }
}


namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyTerminalBlock : VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        event Action<Sandbox.ModAPI.IMyTerminalBlock, StringBuilder> AppendingCustomInfo;

        event Action<Sandbox.ModAPI.IMyTerminalBlock> CustomDataChanged;

        event Action<Sandbox.ModAPI.IMyTerminalBlock> CustomNameChanged;

        event Action<Sandbox.ModAPI.IMyTerminalBlock> OwnershipChanged;

        event Action<Sandbox.ModAPI.IMyTerminalBlock> PropertiesChanged;

        event Action<Sandbox.ModAPI.IMyTerminalBlock> ShowOnHUDChanged;

        event Action<Sandbox.ModAPI.IMyTerminalBlock> VisibilityChanged;

        void RefreshCustomInfo();
    }
}


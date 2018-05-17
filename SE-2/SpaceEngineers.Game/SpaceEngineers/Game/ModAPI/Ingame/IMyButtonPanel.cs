namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyButtonPanel : IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void ClearCustomButtonName(int index);
        string GetButtonName(int index);
        bool HasCustomButtonName(int index);
        bool IsButtonAssigned(int index);
        void SetCustomButtonName(int index, string name);

        bool AnyoneCanUse { get; set; }
    }
}


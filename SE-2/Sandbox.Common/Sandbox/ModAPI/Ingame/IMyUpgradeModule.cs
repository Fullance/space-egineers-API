namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyUpgradeModule : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void GetUpgradeList(out List<MyUpgradeModuleInfo> upgrades);

        uint Connections { get; }

        uint UpgradeCount { get; }
    }
}


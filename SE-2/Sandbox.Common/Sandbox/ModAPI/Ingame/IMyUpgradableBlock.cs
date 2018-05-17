namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyUpgradableBlock : IMyCubeBlock, IMyEntity
    {
        void GetUpgrades(out Dictionary<string, float> upgrades);

        uint UpgradeCount { get; }
    }
}


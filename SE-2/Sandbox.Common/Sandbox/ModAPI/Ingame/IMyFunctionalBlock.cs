namespace Sandbox.ModAPI.Ingame
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyFunctionalBlock : IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        [Obsolete("Use the setter of Enabled")]
        void RequestEnable(bool enable);

        bool Enabled { get; set; }
    }
}


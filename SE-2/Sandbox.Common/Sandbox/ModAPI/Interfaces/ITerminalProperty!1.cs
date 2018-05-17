namespace Sandbox.ModAPI.Interfaces
{
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface ITerminalProperty<TValue> : ITerminalProperty
    {
        TValue GetDefaultValue(IMyCubeBlock block);
        TValue GetMaximum(IMyCubeBlock block);
        TValue GetMinimum(IMyCubeBlock block);
        [Obsolete("Use GetMinimum instead")]
        TValue GetMininum(IMyCubeBlock block);
        TValue GetValue(IMyCubeBlock block);
        void SetValue(IMyCubeBlock block, TValue value);
    }
}


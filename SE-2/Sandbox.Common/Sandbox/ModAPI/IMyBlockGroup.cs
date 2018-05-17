namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public interface IMyBlockGroup : Sandbox.ModAPI.Ingame.IMyBlockGroup
    {
        void GetBlocks(List<Sandbox.ModAPI.IMyTerminalBlock> blocks, Func<Sandbox.ModAPI.IMyTerminalBlock, bool> collect = null);
        void GetBlocksOfType<T>(List<Sandbox.ModAPI.IMyTerminalBlock> blocks, Func<Sandbox.ModAPI.IMyTerminalBlock, bool> collect = null) where T: class;
    }
}


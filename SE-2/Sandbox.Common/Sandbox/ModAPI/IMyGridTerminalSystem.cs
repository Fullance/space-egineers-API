namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public interface IMyGridTerminalSystem : Sandbox.ModAPI.Ingame.IMyGridTerminalSystem
    {
        void GetBlockGroups(List<Sandbox.ModAPI.IMyBlockGroup> blockGroups);
        Sandbox.ModAPI.IMyBlockGroup GetBlockGroupWithName(string name);
        void GetBlocks(List<Sandbox.ModAPI.IMyTerminalBlock> blocks);
        void GetBlocksOfType<T>(List<Sandbox.ModAPI.IMyTerminalBlock> blocks, Func<Sandbox.ModAPI.IMyTerminalBlock, bool> collect = null);
        Sandbox.ModAPI.IMyTerminalBlock GetBlockWithName(string name);
        void SearchBlocksOfName(string name, List<Sandbox.ModAPI.IMyTerminalBlock> blocks, Func<Sandbox.ModAPI.IMyTerminalBlock, bool> collect = null);
    }
}


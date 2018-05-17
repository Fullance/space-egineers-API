namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI;

    public interface IMyTerminalActionsHelper
    {
        void GetActions(Type blockType, List<ITerminalAction> resultList, Func<ITerminalAction, bool> collect = null);
        ITerminalAction GetActionWithName(string nameType, Type blockType);
        void GetProperties(Type blockType, List<ITerminalProperty> resultList, Func<ITerminalProperty, bool> collect = null);
        ITerminalProperty GetProperty(string id, Type blockType);
        IMyGridTerminalSystem GetTerminalSystemForGrid(IMyCubeGrid grid);
        void SearchActionsOfName(string name, Type blockType, List<ITerminalAction> resultList, Func<ITerminalAction, bool> collect = null);
    }
}


namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using VRage.Game;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyConveyorSorter : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void AddItem(MyInventoryItemFilter item);
        void GetFilterList(List<MyInventoryItemFilter> items);
        bool IsAllowed(MyDefinitionId id);
        void RemoveItem(MyInventoryItemFilter item);
        void SetFilter(MyConveyorSorterMode mode, List<MyInventoryItemFilter> items);

        bool DrainAll { get; set; }

        MyConveyorSorterMode Mode { get; }
    }
}


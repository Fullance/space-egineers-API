namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.Game;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ObjectBuilders;

    public interface IMyInventory : VRage.Game.ModAPI.Ingame.IMyInventory
    {
        void AddItems(MyFixedPoint amount, MyObjectBuilder_PhysicalObject objectBuilder, int index = -1);
        void Clear(bool sync = true);
        bool Empty();
        VRage.Game.ModAPI.IMyInventoryItem FindItem(SerializableDefinitionId contentId);
        VRage.Game.ModAPI.IMyInventoryItem GetItemByID(uint id);
        List<VRage.Game.ModAPI.IMyInventoryItem> GetItems();
        void RemoveItems(uint itemId, MyFixedPoint? amount = new MyFixedPoint?(), bool sendEvent = true, bool spawn = false);
        void RemoveItemsAt(int itemIndex, MyFixedPoint? amount = new MyFixedPoint?(), bool sendEvent = true, bool spawn = false);
        void RemoveItemsOfType(MyFixedPoint amount, MyObjectBuilder_PhysicalObject objectBuilder, bool spawn = false);
        void RemoveItemsOfType(MyFixedPoint amount, SerializableDefinitionId contentId, MyItemFlags flags = 0, bool spawn = false);
        bool TransferItemFrom(VRage.Game.ModAPI.IMyInventory sourceInventory, int sourceItemIndex, int? targetItemIndex = new int?(), bool? stackIfPossible = new bool?(), MyFixedPoint? amount = new MyFixedPoint?(), bool checkConnection = true);
        bool TransferItemTo(VRage.Game.ModAPI.IMyInventory dst, int sourceItemIndex, int? targetItemIndex = new int?(), bool? stackIfPossible = new bool?(), MyFixedPoint? amount = new MyFixedPoint?(), bool checkConnection = true);
    }
}


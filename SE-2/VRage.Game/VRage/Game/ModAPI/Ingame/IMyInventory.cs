namespace VRage.Game.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.Game;
    using VRage.ObjectBuilders;
    using VRageMath;

    public interface IMyInventory
    {
        bool CanItemsBeAdded(MyFixedPoint amount, SerializableDefinitionId contentId);
        bool ContainItems(MyFixedPoint amount, MyObjectBuilder_PhysicalObject ob);
        IMyInventoryItem FindItem(SerializableDefinitionId contentId);
        MyFixedPoint GetItemAmount(SerializableDefinitionId contentId, MyItemFlags flags = 0);
        IMyInventoryItem GetItemByID(uint id);
        List<IMyInventoryItem> GetItems();
        bool IsConnectedTo(IMyInventory dst);
        bool IsItemAt(int position);
        bool TransferItemFrom(IMyInventory sourceInventory, int sourceItemIndex, int? targetItemIndex = new int?(), bool? stackIfPossible = new bool?(), MyFixedPoint? amount = new MyFixedPoint?());
        bool TransferItemTo(IMyInventory dst, int sourceItemIndex, int? targetItemIndex = new int?(), bool? stackIfPossible = new bool?(), MyFixedPoint? amount = new MyFixedPoint?());

        MyFixedPoint CurrentMass { get; }

        MyFixedPoint CurrentVolume { get; }

        bool IsFull { get; }

        MyFixedPoint MaxVolume { get; }

        IMyInventoryOwner Owner { get; }

        Vector3 Size { get; }
    }
}


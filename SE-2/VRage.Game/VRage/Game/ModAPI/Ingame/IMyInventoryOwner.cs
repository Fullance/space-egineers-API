namespace VRage.Game.ModAPI.Ingame
{
    using System;

    [Obsolete("IMyInventoryOwner interface and MyInventoryOwnerTypeEnum enum is obsolete. Use type checking and inventory methods on MyEntity.")]
    public interface IMyInventoryOwner
    {
        IMyInventory GetInventory(int index);

        long EntityId { get; }

        bool HasInventory { get; }

        int InventoryCount { get; }

        bool UseConveyorSystem { get; set; }
    }
}


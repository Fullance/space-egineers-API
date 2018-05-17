namespace VRage.Game.ModAPI.Ingame
{
    using System;
    using VRage.Game.Components;
    using VRageMath;

    public interface IMyEntity
    {
        IMyInventory GetInventory();
        IMyInventory GetInventory(int index);
        Vector3D GetPosition();

        MyEntityComponentContainer Components { get; }

        string DisplayName { get; }

        long EntityId { get; }

        bool HasInventory { get; }

        int InventoryCount { get; }

        string Name { get; }

        BoundingBoxD WorldAABB { get; }

        BoundingBoxD WorldAABBHr { get; }

        MatrixD WorldMatrix { get; }

        BoundingSphereD WorldVolume { get; }

        BoundingSphereD WorldVolumeHr { get; }
    }
}


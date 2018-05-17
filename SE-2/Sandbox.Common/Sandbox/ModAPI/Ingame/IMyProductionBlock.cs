namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using VRage;
    using VRage.Game;
    using VRage.Game.ModAPI.Ingame;

    public interface IMyProductionBlock : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void AddQueueItem(MyDefinitionId blueprint, decimal amount);
        void AddQueueItem(MyDefinitionId blueprint, double amount);
        void AddQueueItem(MyDefinitionId blueprint, MyFixedPoint amount);
        bool CanUseBlueprint(MyDefinitionId blueprint);
        void ClearQueue();
        void GetQueue(List<MyProductionItem> items);
        void InsertQueueItem(int idx, MyDefinitionId blueprint, decimal amount);
        void InsertQueueItem(int idx, MyDefinitionId blueprint, double amount);
        void InsertQueueItem(int idx, MyDefinitionId blueprint, MyFixedPoint amount);
        void MoveQueueItemRequest(uint queueItemId, int targetIdx);
        void RemoveQueueItem(int idx, decimal amount);
        void RemoveQueueItem(int idx, double amount);
        void RemoveQueueItem(int idx, MyFixedPoint amount);

        IMyInventory InputInventory { get; }

        bool IsProducing { get; }

        bool IsQueueEmpty { get; }

        uint NextItemId { get; }

        IMyInventory OutputInventory { get; }

        bool UseConveyorSystem { get; set; }
    }
}


namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Collections.Generic;
    using VRage;
    using VRage.Game;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyProductionBlock : Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyProductionBlock, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        event Action StartedProducing;

        event Action StoppedProducing;

        void AddQueueItem(MyDefinitionBase blueprint, MyFixedPoint amount);
        bool CanUseBlueprint(MyDefinitionBase blueprint);
        List<MyProductionQueueItem> GetQueue();
        void InsertQueueItem(int idx, MyDefinitionBase blueprint, MyFixedPoint amount);

        VRage.Game.ModAPI.IMyInventory InputInventory { get; }

        VRage.Game.ModAPI.IMyInventory OutputInventory { get; }
    }
}


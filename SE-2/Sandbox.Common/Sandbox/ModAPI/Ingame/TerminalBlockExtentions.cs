namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using VRage.Game.Entity;
    using VRage.Game.ModAPI.Ingame;

    public static class TerminalBlockExtentions
    {
        public static void ApplyAction(this IMyTerminalBlock block, string actionName)
        {
            block.GetActionWithName(actionName).Apply(block);
        }

        public static void ApplyAction(this IMyTerminalBlock block, string actionName, List<TerminalActionParameter> parameters)
        {
            block.GetActionWithName(actionName).Apply(block, parameters);
        }

        public static long GetId(this IMyTerminalBlock block) => 
            block.EntityId;

        [Obsolete("Use the GetInventoryBase method.")]
        public static IMyInventory GetInventory(this IMyTerminalBlock block, int index)
        {
            MyEntity entity = block as MyEntity;
            if (entity == null)
            {
                return null;
            }
            if (!entity.HasInventory)
            {
                return null;
            }
            return (entity.GetInventoryBase(index) as IMyInventory);
        }

        [Obsolete("Use the InventoryCount property.")]
        public static int GetInventoryCount(this IMyTerminalBlock block)
        {
            MyEntity entity = block as MyEntity;
            return entity?.InventoryCount;
        }

        [Obsolete("Use the blocks themselves, this method is no longer reliable")]
        public static bool GetUseConveyorSystem(this IMyTerminalBlock block) => 
            ((block is IMyInventoryOwner) && ((IMyInventoryOwner) block).UseConveyorSystem);

        public static bool HasAction(this IMyTerminalBlock block, string actionName) => 
            (block.GetActionWithName(actionName) != null);

        [Obsolete("Use the HasInventory property.")]
        public static bool HasInventory(this IMyTerminalBlock block)
        {
            MyEntity entity = block as MyEntity;
            return (((entity != null) && (block is IMyInventoryOwner)) && entity.HasInventory);
        }

        [Obsolete("Use the blocks themselves, this method is no longer reliable")]
        public static void SetUseConveyorSystem(this IMyTerminalBlock block, bool use)
        {
            if (block is IMyInventoryOwner)
            {
                ((IMyInventoryOwner) block).UseConveyorSystem = use;
            }
        }
    }
}


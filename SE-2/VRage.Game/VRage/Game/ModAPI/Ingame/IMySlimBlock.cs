namespace VRage.Game.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using VRage.ObjectBuilders;
    using VRageMath;

    public interface IMySlimBlock
    {
        void GetMissingComponents(Dictionary<string, int> addToDictionary);

        float AccumulatedDamage { get; }

        SerializableDefinitionId BlockDefinition { get; }

        float BuildIntegrity { get; }

        float BuildLevelRatio { get; }

        Vector3 ColorMaskHSV { get; }

        IMyCubeGrid CubeGrid { get; }

        float CurrentDamage { get; }

        float DamageRatio { get; }

        IMyCubeBlock FatBlock { get; }

        bool HasDeformation { get; }

        bool IsDestroyed { get; }

        bool IsFullIntegrity { get; }

        bool IsFullyDismounted { get; }

        float Mass { get; }

        float MaxDeformation { get; }

        float MaxIntegrity { get; }

        long OwnerId { get; }

        Vector3I Position { get; }

        bool ShowParts { get; }

        bool StockpileAllocated { get; }

        bool StockpileEmpty { get; }
    }
}


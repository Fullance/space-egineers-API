namespace VRage.Game.ModAPI.Ingame
{
    using System;
    using VRage.Game;
    using VRage.ObjectBuilders;
    using VRageMath;

    public interface IMyCubeBlock : IMyEntity
    {
        string GetOwnerFactionTag();
        [Obsolete("GetPlayerRelationToOwner() is useless ingame. Mods should use the one in ModAPI.IMyCubeBlock")]
        MyRelationsBetweenPlayerAndBlock GetPlayerRelationToOwner();
        MyRelationsBetweenPlayerAndBlock GetUserRelationToOwner(long playerId);
        [Obsolete]
        void UpdateIsWorking();
        [Obsolete]
        void UpdateVisual();

        SerializableDefinitionId BlockDefinition { get; }

        bool CheckConnectionAllowed { get; }

        IMyCubeGrid CubeGrid { get; }

        string DefinitionDisplayNameText { get; }

        float DisassembleRatio { get; }

        string DisplayNameText { get; }

        bool IsBeingHacked { get; }

        bool IsFunctional { get; }

        bool IsWorking { get; }

        float Mass { get; }

        Vector3I Max { get; }

        Vector3I Min { get; }

        int NumberInGrid { get; }

        MyBlockOrientation Orientation { get; }

        long OwnerId { get; }

        Vector3I Position { get; }
    }
}


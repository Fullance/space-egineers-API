namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Collections;
    using VRage.Game;
    using VRage.ModAPI;
    using VRageMath;

    public interface IMyPlayer
    {
        event Action<IMyPlayer, IMyIdentity> IdentityChanged;

        void AddGrid(long gridEntityId);
        void ChangeOrSwitchToColor(Vector3 color);
        Vector3D GetPosition();
        MyRelationsBetweenPlayerAndBlock GetRelationTo(long playerId);
        void RemoveGrid(long gridEntityId);
        void SetDefaultColors();
        void SpawnAt(MatrixD worldMatrix, Vector3 velocity, IMyEntity spawnedBy);
        void SpawnAt(MatrixD worldMatrix, Vector3 velocity, IMyEntity spawnedBy, bool findFreePlace = true);
        void SpawnIntoCharacter(IMyCharacter character);

        List<Vector3> BuildColorSlots { get; set; }

        IMyCharacter Character { get; }

        IMyNetworkClient Client { get; }

        IMyEntityController Controller { get; }

        ListReader<Vector3> DefaultBuildColorSlots { get; }

        string DisplayName { get; }

        HashSet<long> Grids { get; }

        IMyIdentity Identity { get; }

        long IdentityId { get; }

        [Obsolete("Use Promote Level instead")]
        bool IsAdmin { get; }

        bool IsBot { get; }

        [Obsolete("Use Promote Level instead")]
        bool IsPromoted { get; }

        [Obsolete("Use IdentityId instead.")]
        long PlayerID { get; }

        MyPromoteLevel PromoteLevel { get; }

        ListReader<long> RespawnShip { get; }

        Vector3 SelectedBuildColor { get; set; }

        int SelectedBuildColorSlot { get; set; }

        ulong SteamUserId { get; }
    }
}


namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI.Interfaces;
    using VRage.ModAPI;

    public interface IMyPlayerCollection
    {
        void ExtendControl(IMyControllableEntity entityWithControl, IMyEntity entityGettingControl);
        void GetAllIdentites(List<IMyIdentity> identities, Func<IMyIdentity, bool> collect = null);
        IMyPlayer GetPlayerControllingEntity(IMyEntity entity);
        void GetPlayers(List<IMyPlayer> players, Func<IMyPlayer, bool> collect = null);
        bool HasExtendedControl(IMyControllableEntity firstEntity, IMyEntity secondEntity);
        void ReduceControl(IMyControllableEntity entityWhichKeepsControl, IMyEntity entityWhichLoosesControl);
        void RemoveControlledEntity(IMyEntity entity);
        void SetControlledEntity(ulong steamUserId, IMyEntity entity);
        void TryExtendControl(IMyControllableEntity entityWithControl, IMyEntity entityGettingControl);
        long TryGetIdentityId(ulong steamId);
        ulong TryGetSteamId(long identityId);
        bool TryReduceControl(IMyControllableEntity entityWhichKeepsControl, IMyEntity entityWhichLoosesControl);

        long Count { get; }
    }
}


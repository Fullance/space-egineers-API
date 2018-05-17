namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;

    public interface IMyFactionCollection
    {
        event Action<long, bool, bool> FactionAutoAcceptChanged;

        event Action<long> FactionCreated;

        event Action<long> FactionEdited;

        event Action<MyFactionStateChange, long, long, long, long> FactionStateChanged;

        void AcceptJoin(long factionId, long playerId);
        void AcceptPeace(long fromFactionId, long toFactionId);
        void AddNewNPCToFaction(long factionId);
        [Obsolete("Use SendJoinRequest instead, this will be removed in future")]
        void AddPlayerToFaction(long playerId, long factionId);
        bool AreFactionsEnemies(long factionId1, long factionId2);
        void CancelJoinRequest(long factionId, long playerId);
        void CancelPeaceRequest(long fromFactionId, long toFactionId);
        void ChangeAutoAccept(long factionId, long playerId, bool autoAcceptMember, bool autoAcceptPeace);
        void CreateFaction(long founderId, string tag, string name, string desc, string privateInfo);
        void CreateNPCFaction(string tag, string name, string desc, string privateInfo);
        void DeclareWar(long fromFactionId, long toFactionId);
        void DemoteMember(long factionId, long playerId);
        void EditFaction(long factionId, string tag, string name, string desc, string privateInfo);
        bool FactionNameExists(string name, IMyFaction doNotCheck = null);
        bool FactionTagExists(string tag, IMyFaction doNotCheck = null);
        MyObjectBuilder_FactionCollection GetObjectBuilder();
        MyRelationsBetweenFactions GetRelationBetweenFactions(long factionId1, long factionId2);
        bool IsPeaceRequestStatePending(long myFactionId, long foreignFactionId);
        bool IsPeaceRequestStateSent(long myFactionId, long foreignFactionId);
        void KickMember(long factionId, long playerId);
        [Obsolete("Use KickMember instead, this will be removed in future")]
        void KickPlayerFromFaction(long playerId);
        void MemberLeaves(long factionId, long playerId);
        void PromoteMember(long factionId, long playerId);
        void RemoveFaction(long factionId);
        void SendJoinRequest(long factionId, long playerId);
        void SendPeaceRequest(long fromFactionId, long toFactionId);
        IMyFaction TryGetFactionById(long factionId);
        IMyFaction TryGetFactionByName(string name);
        IMyFaction TryGetFactionByTag(string tag);
        IMyFaction TryGetPlayerFaction(long playerId);

        Dictionary<long, IMyFaction> Factions { get; }
    }
}


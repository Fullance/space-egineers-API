namespace VRage.Game.ModAPI
{
    using System;
    using VRage.Collections;

    public interface IMyFaction
    {
        bool IsEveryoneNpc();
        bool IsFounder(long playerId);
        bool IsLeader(long playerId);
        bool IsMember(long playerId);
        bool IsNeutral(long playerId);

        bool AcceptHumans { get; }

        bool AutoAcceptMember { get; }

        bool AutoAcceptPeace { get; }

        string Description { get; }

        long FactionId { get; }

        long FounderId { get; }

        DictionaryReader<long, MyFactionMember> JoinRequests { get; }

        DictionaryReader<long, MyFactionMember> Members { get; }

        string Name { get; }

        string PrivateInfo { get; }

        string Tag { get; }
    }
}


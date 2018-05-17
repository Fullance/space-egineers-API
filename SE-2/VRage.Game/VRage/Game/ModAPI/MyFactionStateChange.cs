namespace VRage.Game.ModAPI
{
    using System;

    public enum MyFactionStateChange
    {
        RemoveFaction,
        SendPeaceRequest,
        CancelPeaceRequest,
        AcceptPeace,
        DeclareWar,
        FactionMemberSendJoin,
        FactionMemberCancelJoin,
        FactionMemberAcceptJoin,
        FactionMemberKick,
        FactionMemberPromote,
        FactionMemberDemote,
        FactionMemberLeave
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyObjectBuilder_FactionRelation
    {
        [ProtoMember(0x1b)]
        public long FactionId1;
        [ProtoMember(30)]
        public long FactionId2;
        [ProtoMember(0x21)]
        public MyRelationsBetweenFactions Relation;
    }
}


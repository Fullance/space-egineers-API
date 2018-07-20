namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyObjectBuilder_FactionMember
    {
        [ProtoMember(10)]
        public long PlayerId;
        [ProtoMember(13)]
        public bool IsLeader;
        [ProtoMember(0x10)]
        public bool IsFounder;
    }
}


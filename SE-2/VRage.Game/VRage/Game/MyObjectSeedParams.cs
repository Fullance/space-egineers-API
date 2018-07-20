namespace VRage.Game
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class MyObjectSeedParams
    {
        [ProtoMember(0x1b)]
        public bool Generated;
        [ProtoMember(0x15)]
        public int Index;
        [ProtoMember(0x1d)]
        public int m_proxyId = -1;
        [ProtoMember(0x17)]
        public int Seed;
        [ProtoMember(0x19)]
        public MyObjectSeedType Type;
    }
}


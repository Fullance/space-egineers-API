namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyObjectBuilder_FactionRequests
    {
        [ProtoMember(40)]
        public long FactionId;
        [ProtoMember(0x2b)]
        public List<long> FactionRequests;
    }
}


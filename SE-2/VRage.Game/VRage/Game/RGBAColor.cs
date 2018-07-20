namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct RGBAColor
    {
        [ProtoMember(20)]
        public int R;
        [ProtoMember(0x17)]
        public int G;
        [ProtoMember(0x1a)]
        public int B;
        [ProtoMember(0x1d)]
        public int A;
    }
}


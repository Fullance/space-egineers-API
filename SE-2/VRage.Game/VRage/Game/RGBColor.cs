namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct RGBColor
    {
        [ProtoMember(0x24)]
        public int R;
        [ProtoMember(0x27)]
        public int G;
        [ProtoMember(0x2a)]
        public int B;
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct AnimationItem
    {
        [ProtoMember(12)]
        public float Ratio;
        [ProtoMember(15)]
        public string Animation;
    }
}


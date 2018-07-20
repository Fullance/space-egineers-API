namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct AnimationSet
    {
        [ProtoMember(0x16)]
        public float Probability;
        [ProtoMember(0x19)]
        public bool Continuous;
        [ProtoMember(0x1c)]
        public AnimationItem[] AnimationItems;
    }
}


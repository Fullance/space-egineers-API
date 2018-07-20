namespace VRage.Game
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class MyJetpackThrustDefinition
    {
        [ProtoMember(0x1c)]
        public float FrontFlameOffset = 0.04f;
        [ProtoMember(0x19)]
        public float SideFlameOffset = 0.12f;
        [ProtoMember(0x16)]
        public string ThrustBone;
    }
}


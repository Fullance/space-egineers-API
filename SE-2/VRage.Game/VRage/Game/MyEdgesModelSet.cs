namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRage.Data;

    [ProtoContract]
    public class MyEdgesModelSet
    {
        [ModdableContentFile("mwm"), ProtoMember(0x12)]
        public string Horisontal;
        [ModdableContentFile("mwm"), ProtoMember(0x16)]
        public string HorisontalDiagonal;
        [ModdableContentFile("mwm"), ProtoMember(10)]
        public string Vertical;
        [ModdableContentFile("mwm"), ProtoMember(14)]
        public string VerticalDiagonal;
    }
}


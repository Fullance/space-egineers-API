namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRageMath;

    [ProtoContract]
    public class MyPlanetSurfaceDetail
    {
        [ProtoMember(0x13c)]
        public float Scale;
        [ProtoMember(0x139)]
        public float Size;
        [ProtoMember(0x13f)]
        public SerializableRange Slope;
        [ProtoMember(310)]
        public string Texture;
        [ProtoMember(0x142)]
        public float Transition;
    }
}


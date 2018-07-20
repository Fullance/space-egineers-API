namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRage;

    [ProtoContract]
    public class MyObjectBuilder_DeadBodyShape
    {
        [ProtoMember(0x76)]
        public SerializableVector3 BoxShapeScale;
        [ProtoMember(0x7c)]
        public float Friction;
        [ProtoMember(120)]
        public SerializableVector3 RelativeCenterOfMass;
        [ProtoMember(0x7a)]
        public SerializableVector3 RelativeShapeTranslation;
    }
}


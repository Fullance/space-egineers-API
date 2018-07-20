namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyMovementAnimationMapping
    {
        [XmlAttribute, ProtoMember(80)]
        public string AnimationSubtypeName;
        [ProtoMember(0x4d), XmlAttribute]
        public string Name;
    }
}


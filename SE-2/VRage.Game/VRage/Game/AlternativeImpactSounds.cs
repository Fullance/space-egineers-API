namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [XmlType("AlternativeImpactSound"), ProtoContract]
    public sealed class AlternativeImpactSounds
    {
        [XmlAttribute, ProtoMember(0x34)]
        public float mass;
        [ProtoMember(0x3d), XmlAttribute]
        public float maxVolumeVelocity;
        [ProtoMember(0x3a), XmlAttribute]
        public float minVelocity;
        [XmlAttribute, ProtoMember(0x37)]
        public string soundCue = "";
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyPlanetDistortionDefinition
    {
        [ProtoMember(0x167), XmlAttribute(AttributeName="Frequency")]
        public float Frequency = 1f;
        [XmlAttribute(AttributeName="Height"), ProtoMember(0x16b)]
        public float Height = 1f;
        [XmlAttribute(AttributeName="LayerCount"), ProtoMember(0x16f)]
        public int LayerCount = 1;
        [ProtoMember(0x15f), XmlAttribute(AttributeName="Type")]
        public string Type;
        [ProtoMember(0x163), XmlAttribute(AttributeName="Value")]
        public byte Value;
    }
}


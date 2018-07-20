namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyComponentBlockEntry
    {
        [ProtoMember(0x19), XmlAttribute, DefaultValue(true)]
        public bool Enabled = true;
        [XmlAttribute, ProtoMember(0x15)]
        public bool Main = true;
        [ProtoMember(14), XmlAttribute]
        public string Subtype;
        [XmlAttribute, ProtoMember(10)]
        public string Type;
    }
}


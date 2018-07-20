namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;

    [StructLayout(LayoutKind.Sequential), XmlType("ToolSound"), ProtoContract]
    public struct ToolSound
    {
        [XmlAttribute, ProtoMember(180)]
        public string type;
        [XmlAttribute, ProtoMember(0xb7)]
        public string subtype;
        [XmlAttribute, ProtoMember(0xba)]
        public string sound;
    }
}


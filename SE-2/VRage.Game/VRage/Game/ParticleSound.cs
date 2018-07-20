namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("ParticleSound"), ProtoContract]
    public class ParticleSound
    {
        [XmlAttribute("Name"), ProtoMember(0x62)]
        public string Name = "";
        [ProtoMember(0x68)]
        public List<GenerationProperty> Properties;
        [ProtoMember(0x65), XmlAttribute("Version")]
        public int Version;
    }
}


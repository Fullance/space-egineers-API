namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("ParticleLight"), ProtoContract]
    public class ParticleLight
    {
        [ProtoMember(0x55), XmlAttribute("Name")]
        public string Name = "";
        [ProtoMember(0x5b)]
        public List<GenerationProperty> Properties;
        [ProtoMember(0x58), XmlAttribute("Version")]
        public int Version;
    }
}


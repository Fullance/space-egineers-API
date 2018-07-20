namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [ProtoContract, XmlType("ParticleGeneration")]
    public class ParticleGeneration
    {
        [ProtoMember(0x44)]
        public ParticleEmitter Emitter;
        [ProtoMember(0x3e)]
        public string GenerationType = "CPU";
        [XmlAttribute("Name"), ProtoMember(0x38)]
        public string Name = "";
        [ProtoMember(0x41)]
        public List<GenerationProperty> Properties;
        [XmlAttribute("Version"), ProtoMember(0x3b)]
        public int Version;
    }
}


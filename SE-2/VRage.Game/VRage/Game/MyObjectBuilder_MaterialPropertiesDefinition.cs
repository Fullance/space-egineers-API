namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_MaterialPropertiesDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x26)]
        public List<ContactProperty> ContactProperties;
        [XmlArrayItem("Property"), ProtoMember(0x2a)]
        public List<GeneralProperty> GeneralProperties;
        [ProtoMember(0x2d)]
        public string InheritFrom;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct ContactProperty
        {
            [ProtoMember(0x11)]
            public string Type;
            [ProtoMember(0x13)]
            public string Material;
            [ProtoMember(0x15)]
            public string SoundCue;
            [ProtoMember(0x17)]
            public string ParticleEffect;
            [ProtoMember(0x19)]
            public List<VRage.Game.AlternativeImpactSounds> AlternativeImpactSounds;
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct GeneralProperty
        {
            [ProtoMember(0x20)]
            public string Type;
            [ProtoMember(0x22)]
            public string SoundCue;
        }
    }
}


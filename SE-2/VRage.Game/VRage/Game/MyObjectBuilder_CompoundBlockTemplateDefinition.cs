namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CompoundBlockTemplateDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x2e), XmlArrayItem("Binding")]
        public CompoundBlockBinding[] Bindings;

        [ProtoContract]
        public class CompoundBlockBinding
        {
            [ProtoMember(0x20), XmlAttribute]
            public string BuildType;
            [ProtoMember(0x24), XmlAttribute, DefaultValue(false)]
            public bool Multiple;
            [XmlArrayItem("RotationBind"), ProtoMember(0x29)]
            public MyObjectBuilder_CompoundBlockTemplateDefinition.CompoundBlockRotationBinding[] RotationBinds;
        }

        [ProtoContract]
        public class CompoundBlockRotationBinding
        {
            [XmlAttribute, ProtoMember(20)]
            public string BuildTypeReference;
            [ProtoMember(0x18), XmlArrayItem("Rotation")]
            public SerializableBlockOrientation[] Rotations;
        }
    }
}


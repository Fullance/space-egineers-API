namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ContainerDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlArrayItem("Component"), ProtoMember(0x22)]
        public DefaultComponentBuilder[] DefaultComponents;
        [DefaultValue((string) null), ProtoMember(0x26)]
        public EntityFlags? Flags = null;

        [ProtoContract]
        public class DefaultComponentBuilder
        {
            [ProtoMember(0x11), XmlAttribute("BuilderType"), DefaultValue((string) null)]
            public string BuilderType;
            [DefaultValue(false), ProtoMember(0x19), XmlAttribute("ForceCreate")]
            public bool ForceCreate;
            [DefaultValue((string) null), ProtoMember(0x15), XmlAttribute("InstanceType")]
            public string InstanceType;
            [XmlAttribute("SubtypeId"), ProtoMember(0x1d), DefaultValue((string) null)]
            public string SubtypeId;
        }
    }
}


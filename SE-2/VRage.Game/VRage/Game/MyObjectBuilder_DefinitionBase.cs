namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public abstract class MyObjectBuilder_DefinitionBase : MyObjectBuilder_Base
    {
        [DefaultValue(true), ProtoMember(0x22)]
        public bool AvailableInSurvival = true;
        [DefaultValue(""), ProtoMember(20)]
        public string Description;
        [DefaultValue(""), ProtoMember(0x11)]
        public string DisplayName;
        [XmlAttribute(AttributeName="Enabled"), ProtoMember(0x1f), DefaultValue(true)]
        public bool Enabled = true;
        [ModdableContentFile("dds"), XmlElement("Icon"), DefaultValue(new string[] { "" }), ProtoMember(0x17)]
        public string[] Icons;
        [ProtoMember(14)]
        public SerializableDefinitionId Id;
        [ProtoMember(0x1c), DefaultValue(true)]
        public bool Public = true;

        protected MyObjectBuilder_DefinitionBase()
        {
        }
    }
}


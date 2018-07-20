namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_PlayerChatItem : MyObjectBuilder_Base
    {
        [XmlElement(ElementName="I"), ProtoMember(0x40)]
        public long IdentityIdUniqueNumber;
        [XmlElement(ElementName="S"), ProtoMember(70), DefaultValue(true)]
        public bool Sent = true;
        [ProtoMember(0x3d), XmlAttribute("t")]
        public string Text;
        [XmlElement(ElementName="T"), ProtoMember(0x43)]
        public long TimestampMs;
    }
}


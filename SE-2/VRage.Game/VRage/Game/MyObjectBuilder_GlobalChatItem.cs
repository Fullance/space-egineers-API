namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_GlobalChatItem : MyObjectBuilder_Base
    {
        [ProtoMember(0x6a), DefaultValue(""), XmlAttribute("a")]
        public string Author;
        [DefaultValue("Blue"), XmlAttribute("f"), ProtoMember(0x6d)]
        public string Font;
        [ProtoMember(0x67), XmlElement(ElementName="I")]
        public long IdentityIdUniqueNumber;
        [ProtoMember(100), XmlAttribute("t")]
        public string Text;
    }
}


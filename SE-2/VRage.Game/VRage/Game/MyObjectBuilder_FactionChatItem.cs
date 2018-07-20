namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_FactionChatItem : MyObjectBuilder_Base
    {
        [ProtoMember(0x52), XmlElement(ElementName="I")]
        public long IdentityIdUniqueNumber;
        [DefaultValue((string) null), XmlElement(ElementName="IAST"), ProtoMember(0x5b)]
        public List<bool> IsAlreadySentTo;
        [ProtoMember(0x58), DefaultValue((string) null), XmlElement(ElementName="PTST")]
        public List<long> PlayersToSendToUniqueNumber;
        [ProtoMember(0x4f), XmlAttribute("t")]
        public string Text;
        [ProtoMember(0x55), XmlElement(ElementName="T")]
        public long TimestampMs;
    }
}


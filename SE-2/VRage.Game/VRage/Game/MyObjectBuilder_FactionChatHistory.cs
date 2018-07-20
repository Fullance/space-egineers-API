namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_FactionChatHistory : MyObjectBuilder_Base
    {
        [ProtoMember(0x26), XmlArrayItem("FCI")]
        public List<MyObjectBuilder_FactionChatItem> Chat;
        [ProtoMember(0x29), XmlElement(ElementName="ID1")]
        public long FactionId1;
        [XmlElement(ElementName="ID2")]
        public long FactionId2;
    }
}


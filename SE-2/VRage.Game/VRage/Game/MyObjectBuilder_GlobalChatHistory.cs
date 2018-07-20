namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_GlobalChatHistory : MyObjectBuilder_Base
    {
        [XmlArrayItem("GCI"), ProtoMember(0x34)]
        public List<MyObjectBuilder_GlobalChatItem> Chat;
    }
}


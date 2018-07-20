namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_PlayerChatHistory : MyObjectBuilder_Base
    {
        [XmlArrayItem("PCI"), ProtoMember(0x1a)]
        public List<MyObjectBuilder_PlayerChatItem> Chat;
        [XmlElement(ElementName="ID"), ProtoMember(0x1d)]
        public long IdentityId;
    }
}


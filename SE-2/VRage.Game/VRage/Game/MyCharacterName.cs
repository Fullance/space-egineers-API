namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyCharacterName
    {
        [XmlAttribute, ProtoMember(1)]
        public string Name;
    }
}


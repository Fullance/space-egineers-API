namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyMusicCategory
    {
        [ProtoMember(0x1a7), XmlAttribute(AttributeName="Category")]
        public string Category;
        [ProtoMember(0x1ab), XmlAttribute(AttributeName="Frequency")]
        public float Frequency = 1f;
    }
}


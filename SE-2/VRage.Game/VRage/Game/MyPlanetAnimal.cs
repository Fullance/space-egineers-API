namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyPlanetAnimal
    {
        [ProtoMember(0x112), XmlAttribute(AttributeName="Type")]
        public string AnimalType;
    }
}


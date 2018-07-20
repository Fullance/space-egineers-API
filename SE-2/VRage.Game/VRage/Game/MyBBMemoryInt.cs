namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, XmlType("MyBBMemoryInt")]
    public class MyBBMemoryInt : MyBBMemoryValue
    {
        [ProtoMember(10)]
        public int IntValue;
    }
}


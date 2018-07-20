namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [XmlType("MyBBMemoryLong"), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyBBMemoryLong : MyBBMemoryValue
    {
        [ProtoMember(10)]
        public long LongValue;
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, XmlType("MyBBMemoryString")]
    public class MyBBMemoryString : MyBBMemoryValue
    {
        [ProtoMember(10)]
        public string StringValue;
    }
}


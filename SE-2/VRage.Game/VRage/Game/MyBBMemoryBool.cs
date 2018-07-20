namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [XmlType("MyBBMemoryBool"), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyBBMemoryBool : MyBBMemoryValue
    {
        [ProtoMember(10)]
        public bool BoolValue;
    }
}


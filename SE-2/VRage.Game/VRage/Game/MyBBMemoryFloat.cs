namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), XmlType("MyBBMemoryFloat")]
    public class MyBBMemoryFloat : MyBBMemoryValue
    {
        [ProtoMember(10)]
        public float FloatValue;
    }
}


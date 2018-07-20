namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ContainerTypeDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(40), XmlAttribute]
        public int CountMax;
        [XmlAttribute, ProtoMember(0x24)]
        public int CountMin;
        [XmlArrayItem("Item"), ProtoMember(0x2c)]
        public ContainerTypeItem[] Items;

        [ProtoContract]
        public class ContainerTypeItem
        {
            [ProtoMember(0x15), XmlAttribute]
            public string AmountMax;
            [XmlAttribute, ProtoMember(0x11)]
            public string AmountMin;
            [ProtoMember(0x18), DefaultValue((float) 1f)]
            public float Frequency = 1f;
            [ProtoMember(0x1b)]
            public SerializableDefinitionId Id;
        }
    }
}


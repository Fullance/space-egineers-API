namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_HumanoidBotDefinition : MyObjectBuilder_AgentDefinition
    {
        [XmlArrayItem("Item"), ProtoMember(0x1b)]
        public Item[] InventoryItems;
        [ProtoMember(0x17)]
        public Item StartingItem;

        [ProtoContract]
        public class Item
        {
            [ProtoMember(0x13), XmlAttribute]
            public string Subtype;
            [XmlIgnore]
            public MyObjectBuilderType Type = typeof(MyObjectBuilder_PhysicalGunObject);
        }
    }
}


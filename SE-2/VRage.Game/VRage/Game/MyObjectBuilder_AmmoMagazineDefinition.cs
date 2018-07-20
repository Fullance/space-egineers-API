namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_AmmoMagazineDefinition : MyObjectBuilder_PhysicalItemDefinition
    {
        [ProtoMember(0x25)]
        public AmmoDefinition AmmoDefinitionId;
        [ProtoMember(0x1f)]
        public int Capacity;
        [ProtoMember(0x22)]
        public MyAmmoCategoryEnum Category;

        [ProtoContract]
        public class AmmoDefinition
        {
            [ProtoMember(0x1b), XmlAttribute]
            public string Subtype;
            [XmlIgnore]
            public MyObjectBuilderType Type = typeof(MyObjectBuilder_AmmoDefinition);
        }
    }
}


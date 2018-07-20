namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game.ObjectBuilders.Definitions;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ConsumableItemDefinition : MyObjectBuilder_UsableItemDefinition
    {
        [ProtoMember(30), XmlArrayItem("Stat")]
        public StatValue[] Stats;

        [ProtoContract]
        public class StatValue
        {
            [XmlAttribute, ProtoMember(0x10)]
            public string Name;
            [ProtoMember(0x18), XmlAttribute]
            public float Time;
            [ProtoMember(20), XmlAttribute]
            public float Value;
        }
    }
}


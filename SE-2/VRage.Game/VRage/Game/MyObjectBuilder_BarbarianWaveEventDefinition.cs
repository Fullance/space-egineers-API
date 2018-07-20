namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_BarbarianWaveEventDefinition : MyObjectBuilder_GlobalEventDefinition
    {
        [ProtoMember(0x2a), XmlArrayItem("Wave")]
        public WaveDef[] Waves;

        [ProtoContract]
        public class BotDef
        {
            [XmlAttribute, ProtoMember(0x18)]
            public string SubtypeName;
            [ProtoMember(20), XmlAttribute]
            public string TypeName;
        }

        [ProtoContract]
        public class WaveDef
        {
            [XmlArrayItem("Bot"), ProtoMember(0x25)]
            public MyObjectBuilder_BarbarianWaveEventDefinition.BotDef[] Bots;
            [XmlAttribute, ProtoMember(0x20)]
            public int Day;
        }
    }
}


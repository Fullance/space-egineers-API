namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_BotDefinition : MyObjectBuilder_DefinitionBase
    {
        [DefaultValue(""), ProtoMember(30)]
        public string BehaviorSubtype = "";
        [DefaultValue(""), ProtoMember(0x1b)]
        public string BehaviorType = "";
        [ProtoMember(0x18)]
        public BotBehavior BotBehaviorTree;
        [ProtoMember(0x21)]
        public bool Commandable;

        [ProtoContract]
        public class BotBehavior
        {
            [XmlAttribute, ProtoMember(20)]
            public string Subtype;
            [XmlIgnore]
            public MyObjectBuilderType Type = typeof(MyObjectBuilder_BehaviorTreeDefinition);
        }
    }
}


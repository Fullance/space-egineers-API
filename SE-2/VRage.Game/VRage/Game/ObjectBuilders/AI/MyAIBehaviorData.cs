namespace VRage.Game.ObjectBuilders.AI
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyAIBehaviorData : MyObjectBuilder_Base
    {
        [XmlArrayItem("AICategory"), ProtoMember(0x33)]
        public CategorizedData[] Entries;

        [ProtoContract]
        public class ActionData
        {
            [ProtoMember(0x27), XmlAttribute]
            public string ActionName;
            [ProtoMember(0x2e), XmlArrayItem("Param")]
            public MyAIBehaviorData.ParameterData[] Parameters;
            [ProtoMember(0x2a), XmlAttribute]
            public bool ReturnsRunning;
        }

        [ProtoContract]
        public class CategorizedData
        {
            [ProtoMember(15)]
            public string Category;
            [XmlArrayItem("Action"), ProtoMember(0x13)]
            public MyAIBehaviorData.ActionData[] Descriptors;
        }

        [ProtoContract]
        public class ParameterData
        {
            [XmlAttribute, ProtoMember(0x20)]
            public MyMemoryParameterType MemType;
            [ProtoMember(0x1a), XmlAttribute]
            public string Name;
            [XmlAttribute, ProtoMember(0x1d)]
            public string TypeFullName;
        }
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_BotMemory : MyObjectBuilder_Base
    {
        [ProtoMember(0x2b)]
        public BehaviorTreeNodesMemory BehaviorTreeMemory;
        [ProtoMember(0x34)]
        public int LastRunningNodeIndex = -1;
        [ProtoMember(0x2e)]
        public List<int> NewPath;
        [ProtoMember(0x31)]
        public List<int> OldPath;

        [ProtoContract]
        public class BehaviorTreeBlackboardMemory
        {
            [ProtoMember(0x10)]
            public string MemberName;
            [ProtoMember(0x13), XmlElement(Type=typeof(MyAbstractXmlSerializer<MyBBMemoryValue>))]
            public MyBBMemoryValue Value;
        }

        [ProtoContract]
        public class BehaviorTreeNodesMemory
        {
            [ProtoMember(0x1b)]
            public string BehaviorName;
            [ProtoMember(0x24), XmlArrayItem("BBMem")]
            public List<MyObjectBuilder_BotMemory.BehaviorTreeBlackboardMemory> BlackboardMemory;
            [DynamicNullableObjectBuilderItem(false), ProtoMember(0x1f), XmlArrayItem("Node", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_BehaviorTreeNodeMemory>))]
            public List<MyObjectBuilder_BehaviorTreeNodeMemory> Memory;
        }
    }
}


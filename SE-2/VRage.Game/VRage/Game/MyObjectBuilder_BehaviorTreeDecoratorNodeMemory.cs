namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_BehaviorTreeDecoratorNodeMemory : MyObjectBuilder_BehaviorTreeNodeMemory
    {
        [DefaultValue(0), ProtoMember(0x24), XmlAttribute]
        public MyBehaviorTreeState ChildState;
        [ProtoMember(0x27)]
        public LogicMemoryBuilder Logic;

        [ProtoContract]
        public class CounterLogicMemoryBuilder : MyObjectBuilder_BehaviorTreeDecoratorNodeMemory.LogicMemoryBuilder
        {
            [ProtoMember(0x1f)]
            public int CurrentCount;
        }

        [ProtoContract]
        public abstract class LogicMemoryBuilder
        {
            protected LogicMemoryBuilder()
            {
            }
        }

        [ProtoContract]
        public class TimerLogicMemoryBuilder : MyObjectBuilder_BehaviorTreeDecoratorNodeMemory.LogicMemoryBuilder
        {
            [ProtoMember(0x15)]
            public long CurrentTime;
            [ProtoMember(0x18)]
            public bool TimeLimitReached;
        }
    }
}


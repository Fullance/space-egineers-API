namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_BehaviorTreeDecoratorNode : MyObjectBuilder_BehaviorTreeNode
    {
        [ProtoMember(0x25)]
        public MyObjectBuilder_BehaviorTreeNode BTNode;
        [ProtoMember(40)]
        public Logic DecoratorLogic;
        [ProtoMember(0x2b)]
        public MyDecoratorDefaultReturnValues DefaultReturnValue = MyDecoratorDefaultReturnValues.SUCCESS;

        [ProtoContract]
        public class CounterLogic : MyObjectBuilder_BehaviorTreeDecoratorNode.Logic
        {
            [ProtoMember(0x21)]
            public int Count;
        }

        [ProtoContract]
        public abstract class Logic
        {
            protected Logic()
            {
            }
        }

        [ProtoContract]
        public class TimerLogic : MyObjectBuilder_BehaviorTreeDecoratorNode.Logic
        {
            [ProtoMember(0x1a)]
            public long TimeInMs;
        }
    }
}


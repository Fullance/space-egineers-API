namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_Bot : MyObjectBuilder_Base
    {
        [ProtoMember(10)]
        public SerializableDefinitionId BotDefId;
        [ProtoMember(13)]
        public MyObjectBuilder_BotMemory BotMemory;
        [ProtoMember(0x10)]
        public string LastBehaviorTree;
    }
}


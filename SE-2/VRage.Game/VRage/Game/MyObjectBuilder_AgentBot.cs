namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_AgentBot : MyObjectBuilder_Bot
    {
        [ProtoMember(10)]
        public MyObjectBuilder_AiTarget AiTarget;
        [ProtoMember(14)]
        public bool RemoveAfterDeath;
        [ProtoMember(0x11)]
        public int RespawnCounter;
    }
}


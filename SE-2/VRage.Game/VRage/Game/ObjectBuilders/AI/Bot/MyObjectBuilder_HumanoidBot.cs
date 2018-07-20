namespace VRage.Game.ObjectBuilders.AI.Bot
{
    using ProtoBuf;
    using System;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_HumanoidBot : MyObjectBuilder_AgentBot
    {
    }
}


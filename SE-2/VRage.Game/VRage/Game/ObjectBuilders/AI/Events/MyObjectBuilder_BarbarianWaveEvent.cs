namespace VRage.Game.ObjectBuilders.AI.Events
{
    using ProtoBuf;
    using System;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_BarbarianWaveEvent : MyObjectBuilder_GlobalEventBase
    {
        [ProtoMember(10)]
        public int BotsRemaining;
        [ProtoMember(13)]
        public int DayNumber;
    }
}


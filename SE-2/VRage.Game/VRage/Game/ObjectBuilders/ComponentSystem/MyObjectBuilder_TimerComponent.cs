namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_TimerComponent : MyObjectBuilder_ComponentBase
    {
        [ProtoMember(0x19)]
        public bool RemoveEntityOnTimer;
        [ProtoMember(11)]
        public bool Repeat;
        [ProtoMember(0x13)]
        public float SetTimeMinutes;
        [ProtoMember(0x16)]
        public bool TimerEnabled;
        [ProtoMember(14)]
        public float TimeToEvent;
    }
}


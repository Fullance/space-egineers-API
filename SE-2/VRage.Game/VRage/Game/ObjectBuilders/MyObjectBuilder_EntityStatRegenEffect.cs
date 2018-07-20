namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EntityStatRegenEffect : MyObjectBuilder_Base
    {
        [ProtoMember(0x17)]
        public float AliveTime;
        [ProtoMember(0x1a)]
        public float Duration = -1f;
        [ProtoMember(14)]
        public float Interval = 1f;
        [ProtoMember(0x11)]
        public float MaxRegenRatio = 1f;
        [ProtoMember(20)]
        public float MinRegenRatio;
        [ProtoMember(11)]
        public float TickAmount;
    }
}


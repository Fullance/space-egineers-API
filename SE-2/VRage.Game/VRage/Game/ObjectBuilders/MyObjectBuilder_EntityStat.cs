namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EntityStat : MyObjectBuilder_Base
    {
        [ProtoMember(0x18), Serialize(MyObjectFlags.DefaultZero)]
        public MyObjectBuilder_EntityStatRegenEffect[] Effects;
        [ProtoMember(15)]
        public float MaxValue = 1f;
        [ProtoMember(0x12)]
        public float StatRegenAmountMultiplier = 1f;
        [ProtoMember(0x15)]
        public float StatRegenAmountMultiplierDuration;
        [ProtoMember(12)]
        public float Value = 1f;
    }
}


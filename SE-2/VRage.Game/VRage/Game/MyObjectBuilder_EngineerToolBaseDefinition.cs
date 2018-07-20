namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_EngineerToolBaseDefinition : MyObjectBuilder_HandItemDefinition
    {
        [DefaultValue(1), ProtoMember(15)]
        public float DistanceMultiplier = 1f;
        public string Flare = "Welder";
        [ProtoMember(12), DefaultValue(1)]
        public float SpeedMultiplier = 1f;
    }
}


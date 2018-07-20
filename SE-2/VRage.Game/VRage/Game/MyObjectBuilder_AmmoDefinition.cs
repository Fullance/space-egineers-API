namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AmmoDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x58)]
        public AmmoBasicProperties BasicProperties;

        [ProtoContract]
        public class AmmoBasicProperties
        {
            [DefaultValue((float) 0f), ProtoMember(0x52)]
            public float BackkickForce;
            [ProtoMember(0x4a)]
            public float DesiredSpeed;
            [DefaultValue(false), ProtoMember(80)]
            public bool IsExplosive;
            [ProtoMember(0x4e)]
            public float MaxTrajectory;
            [ProtoMember(0x54)]
            public string PhysicalMaterial = "";
            [ProtoMember(0x4c)]
            public float SpeedVariance;
        }
    }
}


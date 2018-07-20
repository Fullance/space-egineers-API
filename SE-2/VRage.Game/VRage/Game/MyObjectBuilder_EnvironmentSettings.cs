namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EnvironmentSettings : MyObjectBuilder_Base
    {
        [ProtoMember(0x1d)]
        public SerializableDefinitionId EnvironmentDefinition = new SerializableDefinitionId(typeof(MyObjectBuilder_EnvironmentDefinition), "Default");
        [ProtoMember(0x1a)]
        public SerializableVector3 FogColor;
        [ProtoMember(0x17)]
        public float FogDensity;
        [ProtoMember(20)]
        public float FogMultiplier;
        [ProtoMember(11)]
        public float SunAzimuth;
        [ProtoMember(14)]
        public float SunElevation;
        [ProtoMember(0x11)]
        public float SunIntensity;
    }
}


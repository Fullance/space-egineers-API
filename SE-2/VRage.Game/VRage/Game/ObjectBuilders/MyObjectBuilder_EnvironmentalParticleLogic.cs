namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EnvironmentalParticleLogic : MyObjectBuilder_Base
    {
        [ProtoMember(0x18)]
        public float Density;
        [ProtoMember(0x15)]
        public float DespawnDistance;
        [ProtoMember(12)]
        public string Material;
        [ProtoMember(0x21)]
        public string MaterialPlanet;
        [ProtoMember(0x1b)]
        public int MaxLifeTime;
        [ProtoMember(30)]
        public int MaxParticles;
        [ProtoMember(0x12)]
        public float MaxSpawnDistance;
        [ProtoMember(15)]
        public Vector4 ParticleColor;
        [ProtoMember(0x24)]
        public Vector4 ParticleColorPlanet;
    }
}


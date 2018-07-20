namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), XmlType("ParticleEffect"), MyObjectBuilderDefinition((Type) null, null)]
    public sealed class MyObjectBuilder_ParticleEffect : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x31)]
        public float DistanceMax;
        [ProtoMember(0x22)]
        public float DurationMax;
        [ProtoMember(0x1f)]
        public float DurationMin;
        [ProtoMember(0x13)]
        public float Length = 10f;
        [ProtoMember(0x1c)]
        public bool Loop;
        [ProtoMember(0x19)]
        public bool LowRes;
        [ProtoMember(40)]
        public List<ParticleGeneration> ParticleGenerations;
        [ProtoMember(0x10)]
        public int ParticleId;
        [ProtoMember(0x2b)]
        public List<ParticleLight> ParticleLights;
        [ProtoMember(0x2e)]
        public List<ParticleSound> ParticleSounds;
        [ProtoMember(0x16)]
        public float Preload;
        [ProtoMember(0x25)]
        public int Version;
    }
}


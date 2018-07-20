namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), XmlType("VoxelMaterial")]
    public class MyObjectBuilder_VoxelMaterialDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x18)]
        public bool CanBeHarvested;
        [ProtoMember(0x60, IsRequired=false)]
        public ColorDefinitionRGBA? ColorKey;
        public string DamagedMaterial;
        [ProtoMember(0x21)]
        public float DamageRatio;
        [ProtoMember(0x34), ModdableContentFile("dds")]
        public string DiffuseXZ;
        [ModdableContentFile("dds"), ProtoMember(60)]
        public string DiffuseY;
        [ProtoMember(90, IsRequired=false)]
        public float Friction = 1f;
        [ProtoMember(0x1b)]
        public bool IsRare;
        [ProtoMember(0x63, IsRequired=false), DefaultValue("")]
        public string LandingEffect;
        [ProtoMember(15)]
        public string MaterialTypeName = "Rock";
        [ProtoMember(0x12)]
        public string MinedOre;
        [ProtoMember(0x15)]
        public float MinedOreRatio;
        [ProtoMember(0x44)]
        public int MinVersion;
        [ProtoMember(0x38), ModdableContentFile("dds")]
        public string NormalXZ;
        [ProtoMember(0x40), ModdableContentFile("dds")]
        public string NormalY;
        [ProtoMember(0x54), DefaultValue("")]
        public string ParticleEffect;
        [ProtoMember(0x5d, IsRequired=false)]
        public float Restitution = 1f;
        [XmlArrayItem("Channel"), ProtoMember(80)]
        public int[] SpawnChannels;
        [ProtoMember(0x4d)]
        public bool SpawnsFlora;
        [ProtoMember(0x4a)]
        public bool SpawnsFromMeteorites = true;
        [ProtoMember(0x47)]
        public bool SpawnsInAsteroids = true;
        [ProtoMember(0x2a)]
        public float SpecularPower;
        [ProtoMember(0x2d)]
        public float SpecularShininess;
        [ProtoMember(0x27)]
        public bool UseTwoTextures;
        [ModdableContentFile("dds"), ProtoMember(0x30)]
        public string VoxelHandPreview;
    }
}


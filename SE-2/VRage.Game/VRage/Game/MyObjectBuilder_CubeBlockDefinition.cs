namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Data;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_CubeBlockDefinition : MyObjectBuilder_PhysicalModelDefinition
    {
        [ProtoMember(0x1fc)]
        public string ActionSound;
        [ProtoMember(0x1ed)]
        public MyAutorotateMode AutorotateMode;
        [ProtoMember(0x1d1)]
        public string BlockPairName;
        [ProtoMember(0x1a5)]
        public MyBlockTopology BlockTopology;
        [DefaultValue((string) null), ProtoMember(0x21a), XmlArrayItem("BlockVariant")]
        public SerializableDefinitionId[] BlockVariants;
        [DefaultValue((string) null), ProtoMember(0x202)]
        public string BuildMaterial;
        [ProtoMember(0x1ce), DefaultValue((string) null), XmlArrayItem("Model")]
        public List<BuildProgressModel> BuildProgressModels;
        [ProtoMember(0x257), DefaultValue(1)]
        public float BuildProgressToPlaceGeneratedBlocks = 1f;
        [DefaultValue((float) 10f), ProtoMember(0x1e7)]
        public float BuildTimeSeconds = 10f;
        [DefaultValue((string) null), ProtoMember(0x1ff)]
        public string BuildType;
        [ProtoMember(0x1d4)]
        public SerializableVector3I? Center;
        [ProtoMember(0x1b6), XmlArrayItem("Component")]
        public CubeBlockComponent[] Components;
        [ProtoMember(0x209), DefaultValue(true)]
        public bool CompoundEnabled = true;
        [DefaultValue((string) null), XmlArrayItem("Template"), ProtoMember(0x206)]
        public string[] CompoundTemplates;
        [ProtoMember(0x25d), DefaultValue(true)]
        public bool CreateFracturedPieces = true;
        [ProtoMember(0x1bd)]
        public CriticalPart CriticalComponent;
        [ProtoMember(0x1b2)]
        public PatternDefinition CubeDefinition;
        [ProtoMember(0x1a2)]
        public MyCubeSize CubeSize;
        [DefaultValue((string) null), ProtoMember(0x25a)]
        public string DamagedSound;
        [DefaultValue(0), ProtoMember(560, IsRequired=false)]
        public int DamageEffectId;
        [ProtoMember(0x266, IsRequired=false), DefaultValue("")]
        public string DamageEffectName = "";
        [DefaultValue((float) 1f), ProtoMember(0x1e1)]
        public float DeformationRatio = 1f;
        [DefaultValue(""), ProtoMember(0x233)]
        public string DestroyEffect = "";
        [ProtoMember(620, IsRequired=false), DefaultValue((string) null)]
        public Vector3? DestroyEffectOffset = null;
        [ProtoMember(0x236), DefaultValue("PoofExplosionCat1")]
        public string DestroySound = "PoofExplosionCat1";
        [ProtoMember(0x21e), DefaultValue(3)]
        public MyBlockDirection Direction = MyBlockDirection.Both;
        [ProtoMember(490), DefaultValue((float) 1f)]
        public float DisassembleRatio = 1f;
        [ProtoMember(0x1e4)]
        public string EdgeType;
        [ProtoMember(0x1ba), XmlArrayItem("Effect")]
        public CubeBlockEffectBase[] Effects;
        [DefaultValue((string) null), ProtoMember(0x260)]
        public string EmissiveColorPreset;
        [XmlArrayItem("Component"), ProtoMember(0x1c7)]
        public EntityComponentDefinition[] EntityComponents;
        [DefaultValue((float) 1f), ProtoMember(0x263)]
        public float GeneralDamageMultiplier = 1f;
        [DefaultValue((string) null), XmlArrayItem("GeneratedBlock"), ProtoMember(550)]
        public SerializableDefinitionId[] GeneratedBlocks;
        [DefaultValue((string) null), ProtoMember(0x229)]
        public string GeneratedBlockType;
        [ProtoMember(0x216), DefaultValue(true)]
        public bool GuiVisible = true;
        [DefaultValue(true), ProtoMember(0x24c)]
        public bool HasPhysics = true;
        [DefaultValue(false), ProtoMember(0x242)]
        public bool IsAirTight;
        [ProtoMember(0x247), DefaultValue(true)]
        public bool IsStandAlone = true;
        [DefaultValue(0), ProtoMember(0x254)]
        public int MaxIntegrity;
        [ProtoMember(0x22d), DefaultValue(false)]
        public bool Mirrored;
        [ProtoMember(0x1f0)]
        public string MirroringBlock;
        [DefaultValue(0), ProtoMember(0x1d8)]
        public MySymmetryAxisEnum MirroringX;
        [ProtoMember(0x1db), DefaultValue(0)]
        public MySymmetryAxisEnum MirroringY;
        [DefaultValue(0), ProtoMember(0x1de)]
        public MySymmetryAxisEnum MirroringZ;
        [ProtoMember(0x1ab)]
        public SerializableVector3 ModelOffset;
        [ProtoMember(0x1c0)]
        public MountPoint[] MountPoints;
        [ProtoMember(0x210), DefaultValue((string) null)]
        public string MultiBlock;
        [ProtoMember(0x213), DefaultValue((string) null)]
        public string NavigationDefinition;
        [DefaultValue(1), ProtoMember(0x26f)]
        public int PCU = 1;
        [DefaultValue(1), ProtoMember(0x1ca)]
        public MyPhysicsOption PhysicsOption = MyPhysicsOption.Box;
        [Obsolete, DefaultValue(1), ProtoMember(0x251)]
        public int Points;
        [ProtoMember(0x1f9)]
        public string PrimarySound;
        [DefaultValue(false), ProtoMember(0x23e)]
        public bool RandomRotation;
        [DefaultValue(3), ProtoMember(0x222)]
        public MyBlockRotation Rotation = MyBlockRotation.Both;
        [DefaultValue(false), ProtoMember(0x19f)]
        public bool SilenceableByShipSoundSystem;
        [ProtoMember(0x1a8)]
        public SerializableVector3I Size;
        [ProtoMember(570), DefaultValue((string) null)]
        public List<BoneInfo> Skeleton;
        [XmlArrayItem("Definition"), ProtoMember(0x20d), DefaultValue((string) null)]
        public MySubBlockDefinition[] SubBlockDefinitions;
        [ProtoMember(0x1f3)]
        public bool UseModelIntersection;
        public bool UseNeighbourOxygenRooms;
        [ProtoMember(0x269, IsRequired=false), DefaultValue(true)]
        public bool UsesDeformation = true;
        [ProtoMember(0x1c3)]
        public Variant[] Variants;
        public VoxelPlacementOverride? VoxelPlacement = null;

        public bool ShouldSerializeCenter() => 
            this.Center.HasValue;

        [ProtoContract]
        public class BuildProgressModel
        {
            [XmlAttribute, ProtoMember(0x13a)]
            public float BuildPercentUpperBound;
            [XmlAttribute, ProtoMember(0x13e), ModdableContentFile("mwm")]
            public string File;
            [XmlArray("MountPointOverrides"), ProtoMember(0x146), DefaultValue((string) null), XmlArrayItem("MountPoint")]
            public MyObjectBuilder_CubeBlockDefinition.MountPoint[] MountPoints;
            [XmlAttribute, DefaultValue(false), ProtoMember(0x143)]
            public bool RandomOrientation;
            [XmlAttribute, DefaultValue(true), ProtoMember(0x14c)]
            public bool Visible = true;
        }

        [ProtoContract]
        public class CriticalPart
        {
            [ProtoMember(0xfd), XmlAttribute]
            public int Index;
            [XmlAttribute, ProtoMember(250)]
            public string Subtype;
            [XmlIgnore]
            public MyObjectBuilderType Type = typeof(MyObjectBuilder_Component);
        }

        [ProtoContract]
        public class CubeBlockComponent
        {
            [ProtoMember(0xec), XmlAttribute]
            public ushort Count;
            [ProtoMember(0xef)]
            public SerializableDefinitionId DeconstructId;
            [XmlAttribute, ProtoMember(0xe9)]
            public string Subtype;
            [XmlIgnore]
            public MyObjectBuilderType Type = typeof(MyObjectBuilder_Component);
        }

        [ProtoContract]
        public class CubeBlockEffect
        {
            [XmlAttribute, ProtoMember(0x187)]
            public float Delay;
            [XmlAttribute, ProtoMember(0x18b)]
            public float Duration;
            [ProtoMember(0x18f), XmlAttribute]
            public bool Loop;
            [XmlAttribute, ProtoMember(0x17f)]
            public string Name = "";
            [ProtoMember(0x183), XmlAttribute]
            public string Origin = "";
            [ProtoMember(0x197), XmlAttribute]
            public float SpawnTimeMax;
            [XmlAttribute, ProtoMember(0x193)]
            public float SpawnTimeMin;
        }

        [ProtoContract]
        public class CubeBlockEffectBase
        {
            [ProtoMember(0x16b), XmlAttribute]
            public string Name = "";
            [ProtoMember(0x173), XmlAttribute]
            public float ParameterMax = float.MaxValue;
            [XmlAttribute, ProtoMember(0x16f)]
            public float ParameterMin = float.MinValue;
            [ProtoMember(0x177), XmlArrayItem("ParticleEffect")]
            public MyObjectBuilder_CubeBlockDefinition.CubeBlockEffect[] ParticleEffects;
        }

        [ProtoContract]
        public class EntityComponentDefinition
        {
            [XmlAttribute, ProtoMember(0x163)]
            public string BuilderType;
            [ProtoMember(0x15f), XmlAttribute]
            public string ComponentType;
        }

        [ProtoContract]
        public class MountPoint
        {
            [XmlAttribute, ProtoMember(0xdd), DefaultValue(false)]
            public bool Default;
            [XmlAttribute, ProtoMember(0xda), DefaultValue(true)]
            public bool Enabled = true;
            [XmlIgnore, ProtoMember(0xb7)]
            public SerializableVector2 End;
            [XmlAttribute, ProtoMember(0xd4), DefaultValue(0)]
            public byte ExclusionMask;
            [DefaultValue(0), XmlAttribute, ProtoMember(0xd7)]
            public byte PropertiesMask;
            [ProtoMember(0xb1), XmlAttribute]
            public BlockSideEnum Side;
            [ProtoMember(180), XmlIgnore]
            public SerializableVector2 Start;

            [XmlAttribute]
            public float EndX
            {
                get => 
                    this.End.X;
                set
                {
                    this.End.X = value;
                }
            }

            [XmlAttribute]
            public float EndY
            {
                get => 
                    this.End.Y;
                set
                {
                    this.End.Y = value;
                }
            }

            [XmlAttribute]
            public float StartX
            {
                get => 
                    this.Start.X;
                set
                {
                    this.Start.X = value;
                }
            }

            [XmlAttribute]
            public float StartY
            {
                get => 
                    this.Start.Y;
                set
                {
                    this.Start.Y = value;
                }
            }
        }

        [ProtoContract]
        public class MySubBlockDefinition
        {
            [ProtoMember(0x157)]
            public SerializableDefinitionId Id;
            [XmlAttribute, ProtoMember(340)]
            public string SubBlock;
        }

        [ProtoContract]
        public class PatternDefinition
        {
            [ProtoMember(0x113)]
            public MyCubeTopology CubeTopology;
            [ProtoMember(0x117)]
            public bool ShowEdges;
            [ProtoMember(0x115)]
            public MyObjectBuilder_CubeBlockDefinition.Side[] Sides;
        }

        [ProtoContract]
        public class Side
        {
            [ProtoMember(0x11f), XmlAttribute, ModdableContentFile("mwm")]
            public string Model;
            [XmlIgnore, ProtoMember(0x124)]
            public SerializableVector2I PatternSize;

            [XmlAttribute]
            public int PatternHeight
            {
                get => 
                    this.PatternSize.Y;
                set
                {
                    this.PatternSize.Y = value;
                }
            }

            [XmlAttribute]
            public int PatternWidth
            {
                get => 
                    this.PatternSize.X;
                set
                {
                    this.PatternSize.X = value;
                }
            }
        }

        [ProtoContract]
        public class Variant
        {
            [XmlAttribute, ProtoMember(0x109)]
            public string Color;
            [ProtoMember(0x10c), XmlAttribute]
            public string Suffix;
        }
    }
}


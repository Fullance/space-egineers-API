namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Game.Gui;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ToolItemDefinition : MyObjectBuilder_PhysicalItemDefinition
    {
        [ProtoMember(120), DefaultValue(1)]
        public float HitDistance = 1f;
        [ProtoMember(0x71), DefaultValue((string) null), XmlArrayItem("Action")]
        public MyToolActionDefinition[] PrimaryActions;
        [XmlArrayItem("Action"), DefaultValue((string) null), ProtoMember(0x75)]
        public MyToolActionDefinition[] SecondaryActions;
        [XmlArrayItem("Mining"), ProtoMember(0x6d), DefaultValue((string) null)]
        public MyVoxelMiningDefinition[] VoxelMinings;

        [ProtoContract]
        public class MyToolActionDefinition
        {
            [ProtoMember(0x63)]
            public MyHudTexturesEnum Crosshair = MyHudTexturesEnum.HudOre;
            [ProtoMember(0x60), DefaultValue((float) 0f)]
            public float CustomShapeRadius;
            [DefaultValue((float) 1f), ProtoMember(0x4b)]
            public float Efficiency = 1f;
            [ProtoMember(0x48), DefaultValue(1)]
            public float EndTime = 1f;
            [DefaultValue((string) null), ProtoMember(0x67), XmlArrayItem("HitCondition")]
            public MyObjectBuilder_ToolItemDefinition.MyToolActionHitCondition[] HitConditions;
            [ProtoMember(90), DefaultValue((float) 1f)]
            public float HitDuration = 1f;
            [ProtoMember(0x5d), DefaultValue((string) null)]
            public string HitSound;
            [DefaultValue((float) 0f), ProtoMember(0x57)]
            public float HitStart;
            [ProtoMember(0x42)]
            public string Name;
            [ProtoMember(0x45), DefaultValue(0)]
            public float StartTime;
            [ProtoMember(0x4e), DefaultValue((string) null)]
            public string StatsEfficiency;
            [ProtoMember(0x51), DefaultValue((string) null)]
            public string SwingSound;
            [DefaultValue((float) 0f), ProtoMember(0x54)]
            public float SwingSoundStart;
        }

        [ProtoContract]
        public class MyToolActionHitCondition
        {
            [ProtoMember(0x29)]
            public string Animation;
            [ProtoMember(0x2c)]
            public float AnimationTimeScale = 1f;
            [ProtoMember(0x3b)]
            public string Component;
            [ProtoMember(0x26), DefaultValue((string) null)]
            public string[] EntityType;
            [ProtoMember(0x2f)]
            public string StatsAction;
            [ProtoMember(50)]
            public string StatsActionIfHit;
            [ProtoMember(0x35)]
            public string StatsModifier;
            [ProtoMember(0x38)]
            public string StatsModifierIfHit;
        }

        [ProtoContract]
        public class MyVoxelMiningDefinition
        {
            [ProtoMember(0x15), DefaultValue(0)]
            public int HitCount;
            [ProtoMember(0x11), DefaultValue((string) null)]
            public string MinedOre;
            [DefaultValue(false), ProtoMember(0x1f)]
            public bool OnlyApplyMaterial;
            [DefaultValue((string) null), ProtoMember(0x18)]
            public SerializableDefinitionId PhysicalItemId;
            [DefaultValue((float) 0f), ProtoMember(0x1c)]
            public float RemovedRadius;
        }
    }
}


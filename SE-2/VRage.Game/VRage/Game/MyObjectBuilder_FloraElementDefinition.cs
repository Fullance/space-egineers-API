namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_FloraElementDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlArrayItem("Group"), DefaultValue((string) null), ProtoMember(0x36)]
        public string[] AppliedGroups;
        [ProtoMember(0x3d)]
        public MyAreaTransformType AreaTransformType = MyAreaTransformType.ENRICHING;
        [ProtoMember(0x53), DefaultValue(0)]
        public float DecayTime;
        [ProtoMember(0x4d)]
        public int GatherableStep = -1;
        [ProtoMember(80), DefaultValue((string) null)]
        public GatheredItemDef GatheredItem;
        [DefaultValue((string) null), ProtoMember(70), XmlArrayItem("Step")]
        public GrowthStep[] GrowthSteps;
        [DefaultValue(0), ProtoMember(0x43)]
        public float GrowTime;
        [ProtoMember(0x4a)]
        public int PostGatherStep;
        [ProtoMember(0x40), DefaultValue(false)]
        public bool Regrowable;
        [ProtoMember(0x3a)]
        public float SpawnProbability = 1f;

        [ProtoContract]
        public class EnvItem
        {
            [ProtoMember(0x17), XmlAttribute]
            public string Group;
            [ProtoMember(0x1b), XmlAttribute]
            public string Subtype;
        }

        [ProtoContract]
        public class GatheredItemDef
        {
            [ProtoMember(50)]
            public float Amount;
            [ProtoMember(0x2f)]
            public SerializableDefinitionId Id;
        }

        [ProtoContract]
        public class GrowthStep
        {
            [ProtoMember(0x23), XmlAttribute]
            public int GroupInsId = -1;
            [ProtoMember(0x27), XmlAttribute]
            public float Percent = 1f;
        }
    }
}


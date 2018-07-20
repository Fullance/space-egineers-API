namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_SpawnGroupDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x2f), DefaultValue((float) 1f)]
        public float Frequency = 1f;
        [DefaultValue(false), ProtoMember(0x3a)]
        public bool IsEncounter;
        [DefaultValue(false), ProtoMember(0x3d)]
        public bool IsPirate;
        [XmlArrayItem("Prefab"), ProtoMember(50)]
        public SpawnGroupPrefab[] Prefabs;
        [ProtoMember(0x40), DefaultValue(false)]
        public bool ReactorsOn;
        [XmlArrayItem("Voxel"), ProtoMember(0x36)]
        public SpawnGroupVoxel[] Voxels;

        [ProtoContract]
        public class SpawnGroupPrefab
        {
            [DefaultValue(""), ProtoMember(0x18)]
            public string BeaconText = "";
            [ProtoMember(30), DefaultValue(false)]
            public bool PlaceToGridOrigin;
            [ProtoMember(0x15)]
            public Vector3 Position;
            [ProtoMember(0x21)]
            public bool ResetOwnership = true;
            [DefaultValue((float) 10f), ProtoMember(0x1b)]
            public float Speed = 10f;
            [XmlAttribute, ProtoMember(0x12)]
            public string SubtypeId;
        }

        [ProtoContract]
        public class SpawnGroupVoxel
        {
            [ProtoMember(0x2b)]
            public Vector3 Offset;
            [XmlAttribute, ProtoMember(40)]
            public string StorageName;
        }
    }
}


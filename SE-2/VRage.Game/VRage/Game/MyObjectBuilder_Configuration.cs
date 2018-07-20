namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_Configuration : MyObjectBuilder_Base
    {
        [ProtoMember(0x37)]
        public BaseBlockSettings BaseBlockPrefabs;
        [ProtoMember(0x3a)]
        public BaseBlockSettings BaseBlockPrefabsSurvival;
        [ProtoMember(0x34)]
        public CubeSizeSettings CubeSizes;
        [ProtoMember(0x3e)]
        public LootBagDefinition LootBag;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct BaseBlockSettings
        {
            [ProtoMember(0x1c), XmlAttribute]
            public string SmallStatic;
            [ProtoMember(0x1f), XmlAttribute]
            public string LargeStatic;
            [XmlAttribute, ProtoMember(0x22)]
            public string SmallDynamic;
            [ProtoMember(0x25), XmlAttribute]
            public string LargeDynamic;
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct CubeSizeSettings
        {
            [ProtoMember(15), XmlAttribute]
            public float Large;
            [XmlAttribute, ProtoMember(0x12)]
            public float Small;
            [XmlAttribute, ProtoMember(0x15)]
            public float SmallOriginal;
        }

        [ProtoContract]
        public class LootBagDefinition
        {
            [ProtoMember(0x2c)]
            public SerializableDefinitionId ContainerDefinition;
            [XmlAttribute, ProtoMember(0x30)]
            public float SearchRadius = 3f;
        }
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, XmlType("ScenarioDefinition"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ScenarioDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x15)]
        public AsteroidClustersSettings AsteroidClusters;
        [ProtoMember(0x5f)]
        public MyOBBattleSettings Battle;
        [ProtoMember(0x43)]
        public MyObjectBuilder_InventoryItem[] CreativeInventoryItems;
        [ProtoMember(0x2f), XmlArrayItem("AmmoItem")]
        public StartingItem[] CreativeModeAmmoItems;
        [XmlArrayItem("Component"), ProtoMember(0x27)]
        public StartingItem[] CreativeModeComponents;
        [ProtoMember(0x2b), XmlArrayItem("PhysicalItem")]
        public StartingPhysicalItem[] CreativeModePhysicalItems;
        [XmlArrayItem("Weapon"), ProtoMember(0x23)]
        public string[] CreativeModeWeapons;
        [ProtoMember(0x18)]
        public MyEnvironmentHostilityEnum DefaultEnvironment = MyEnvironmentHostilityEnum.NORMAL;
        [ProtoMember(0x12)]
        public SerializableDefinitionId EnvironmentDefinition = new SerializableDefinitionId(typeof(MyObjectBuilder_EnvironmentDefinition), "Default");
        [ProtoMember(0x65)]
        public long GameDate = 0x91bf304a5d29800L;
        [ProtoMember(15)]
        public SerializableDefinitionId GameDefinition = ((SerializableDefinitionId) MyGameDefinition.Default);
        private MyObjectBuilder_Toolbar m_creativeDefaultToolbar;
        [ProtoMember(0x62)]
        public string MainCharacterModel;
        [XmlArrayItem("StartingState", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_WorldGeneratorPlayerStartingState>)), ProtoMember(0x1b)]
        public MyObjectBuilder_WorldGeneratorPlayerStartingState[] PossibleStartingStates;
        [ProtoMember(0x68)]
        public SerializableVector3 SunDirection = Vector3.Invalid;
        [ProtoMember(0x5c)]
        public MyObjectBuilder_Toolbar SurvivalDefaultToolbar;
        [ProtoMember(70)]
        public MyObjectBuilder_InventoryItem[] SurvivalInventoryItems;
        [XmlArrayItem("AmmoItem"), ProtoMember(0x3f)]
        public StartingItem[] SurvivalModeAmmoItems;
        [ProtoMember(0x37), XmlArrayItem("Component")]
        public StartingItem[] SurvivalModeComponents;
        [ProtoMember(0x3b), XmlArrayItem("PhysicalItem")]
        public StartingPhysicalItem[] SurvivalModePhysicalItems;
        [XmlArrayItem("Weapon"), ProtoMember(0x33)]
        public string[] SurvivalModeWeapons;
        [ProtoMember(0x49)]
        public SerializableBoundingBoxD? WorldBoundaries;
        [ProtoMember(0x1f), XmlArrayItem("Operation", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_WorldGeneratorOperation>))]
        public MyObjectBuilder_WorldGeneratorOperation[] WorldGeneratorOperations;

        public bool ShouldSerializeDefaultToolbar() => 
            false;

        [ProtoMember(0x54)]
        public MyObjectBuilder_Toolbar CreativeDefaultToolbar
        {
            get => 
                this.m_creativeDefaultToolbar;
            set
            {
                this.m_creativeDefaultToolbar = value;
            }
        }

        [ProtoMember(0x4c)]
        public MyObjectBuilder_Toolbar DefaultToolbar
        {
            get => 
                null;
            set
            {
                this.CreativeDefaultToolbar = this.SurvivalDefaultToolbar = value;
            }
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct AsteroidClustersSettings
        {
            [XmlAttribute, ProtoMember(110)]
            public bool Enabled;
            [ProtoMember(0x71), XmlAttribute]
            public float Offset;
            [XmlAttribute, ProtoMember(0x75)]
            public bool CentralCluster;
            public bool ShouldSerializeOffset() => 
                this.Enabled;

            public bool ShouldSerializeCentralCluster() => 
                this.Enabled;
        }

        [ProtoContract]
        public class MyOBBattleSettings
        {
            [XmlArrayItem("Slot"), ProtoMember(0x94)]
            public SerializableBoundingBoxD[] AttackerSlots;
            [ProtoMember(0x9b)]
            public long DefenderEntityId;
            [ProtoMember(0x98)]
            public SerializableBoundingBoxD DefenderSlot;
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct StartingItem
        {
            [ProtoMember(0x7d), XmlAttribute]
            public float amount;
            [XmlText, ProtoMember(0x80)]
            public string itemName;
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct StartingPhysicalItem
        {
            [ProtoMember(0x87), XmlAttribute]
            public float amount;
            [XmlText, ProtoMember(0x8a)]
            public string itemName;
            [XmlAttribute, ProtoMember(0x8d)]
            public string itemType;
        }
    }
}


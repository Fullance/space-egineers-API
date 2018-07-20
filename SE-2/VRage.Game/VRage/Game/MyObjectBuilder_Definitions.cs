namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game.ObjectBuilders;
    using VRage.Game.ObjectBuilders.Definitions;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), XmlRoot("Definitions")]
    public class MyObjectBuilder_Definitions : MyObjectBuilder_Base
    {
        [ProtoMember(0xbf), XmlArrayItem("AIBehavior", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_BehaviorTreeDefinition>))]
        public MyObjectBuilder_BehaviorTreeDefinition[] AIBehaviors;
        [XmlArrayItem("AiCommand", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_AiCommandDefinition>)), ProtoMember(0xd7)]
        public MyObjectBuilder_AiCommandDefinition[] AiCommands;
        [XmlArrayItem("AmmoMagazine", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_AmmoMagazineDefinition>)), ProtoMember(0x17)]
        public MyObjectBuilder_AmmoMagazineDefinition[] AmmoMagazines;
        [ProtoMember(0x8f), XmlArrayItem("Ammo", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_AmmoDefinition>))]
        public MyObjectBuilder_AmmoDefinition[] Ammos;
        [ProtoMember(0x53), XmlArrayItem("Animation", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_AnimationDefinition>))]
        public MyObjectBuilder_AnimationDefinition[] Animations;
        [ProtoMember(0xfb), XmlArrayItem("Definition", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_AreaMarkerDefinition>))]
        public MyObjectBuilder_AreaMarkerDefinition[] AreaMarkerDefinitions;
        [ProtoMember(0x97), XmlArrayItem("AssetModifier", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_AssetModifierDefinition>))]
        public MyObjectBuilder_AssetModifierDefinition[] AssetModifiers;
        [XmlArrayItem("Effect", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_AudioEffectDefinition>)), ProtoMember(0xef)]
        public MyObjectBuilder_AudioEffectDefinition[] AudioEffects;
        [ProtoMember(0x102), XmlElement(Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_BattleDefinition>))]
        public MyObjectBuilder_BattleDefinition Battle;
        [ProtoMember(0xdb), XmlArrayItem("NavDef", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_BlockNavigationDefinition>))]
        public MyObjectBuilder_BlockNavigationDefinition[] BlockNavigationDefinitions;
        [XmlArrayItem("BlockPosition"), ProtoMember(0x2b)]
        public MyBlockPosition[] BlockPositions;
        [ProtoMember(0x6b), XmlArrayItem("Entry")]
        public BlueprintClassEntry[] BlueprintClassEntries;
        [XmlArrayItem("Class"), ProtoMember(0x67)]
        public MyObjectBuilder_BlueprintClassDefinition[] BlueprintClasses;
        [XmlArrayItem("Blueprint", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_BlueprintDefinition>)), ProtoMember(0x1b)]
        public MyObjectBuilder_BlueprintDefinition[] Blueprints;
        [ProtoMember(0xcb), XmlArrayItem("Bot", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_BotDefinition>))]
        public MyObjectBuilder_BotDefinition[] Bots;
        [ProtoMember(0x83), XmlArrayItem("Category", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_GuiBlockCategoryDefinition>))]
        public MyObjectBuilder_GuiBlockCategoryDefinition[] CategoryClasses;
        [XmlArrayItem("Entry"), ProtoMember(0xff)]
        public MyCharacterName[] CharacterNames;
        [XmlArrayItem("Character", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_CharacterDefinition>)), ProtoMember(0x4f)]
        public MyObjectBuilder_CharacterDefinition[] Characters;
        [ProtoMember(0x132), XmlArrayItem("Block")]
        public MyComponentBlockEntry[] ComponentBlocks;
        [ProtoMember(0x12a), XmlArrayItem("Group", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ComponentGroupDefinition>))]
        public MyObjectBuilder_ComponentGroupDefinition[] ComponentGroups;
        [XmlArrayItem("Component", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ComponentDefinition>)), ProtoMember(0x1f)]
        public MyObjectBuilder_ComponentDefinition[] Components;
        [XmlArrayItem("Substitution"), ProtoMember(0x12e)]
        public MyObjectBuilder_ComponentSubstitutionDefinition[] ComponentSubstitutions;
        [XmlArrayItem("Template", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_CompoundBlockTemplateDefinition>)), ProtoMember(0x73)]
        public MyObjectBuilder_CompoundBlockTemplateDefinition[] CompoundBlockTemplates;
        [XmlElement(Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_Configuration>)), ProtoMember(0x2e)]
        public MyObjectBuilder_Configuration Configuration;
        [ProtoMember(0x23), XmlArrayItem("ContainerType", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ContainerTypeDefinition>))]
        public MyObjectBuilder_ContainerTypeDefinition[] ContainerTypes;
        [ProtoMember(0xe7), XmlArrayItem("ControllerSchema", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ControllerSchemaDefinition>))]
        public MyObjectBuilder_ControllerSchemaDefinition[] ControllerSchemas;
        [XmlArrayItem("Definition", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_CubeBlockDefinition>)), ProtoMember(0x27)]
        public MyObjectBuilder_CubeBlockDefinition[] CubeBlocks;
        [ProtoMember(0xeb), XmlArrayItem("SoundCurve", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_CurveDefinition>))]
        public MyObjectBuilder_CurveDefinition[] CurveDefinitions;
        [XmlArrayItem("Cutting", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_CuttingDefinition>)), ProtoMember(0xdf)]
        public MyObjectBuilder_CuttingDefinition[] Cuttings;
        [XmlArrayItem("Debris", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_DebrisDefinition>)), ProtoMember(0x57)]
        public MyObjectBuilder_DebrisDefinition[] Debris;
        [ProtoMember(0x106)]
        public MyObjectBuilder_DecalGlobalsDefinition DecalGlobals;
        [ProtoMember(0x10a), XmlArrayItem("Decal")]
        public MyObjectBuilder_DecalDefinition[] Decals;
        [XmlElement("Definition", Type=typeof(MyDefinitionXmlSerializer))]
        public MyObjectBuilder_DefinitionBase[] Definitions;
        [ProtoMember(0x149)]
        public MyObjectBuilder_DestructionDefinition Destruction;
        [ProtoMember(0xb2), XmlArrayItem("DroneBehavior", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_DroneBehaviorDefinition>))]
        public MyObjectBuilder_DroneBehaviorDefinition[] DroneBehaviors;
        [ProtoMember(0x7b), XmlArrayItem("DropContainer", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_DropContainerDefinition>))]
        public MyObjectBuilder_DropContainerDefinition[] DropContainers;
        [XmlArrayItem("Edges", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_EdgesDefinition>)), ProtoMember(0x5b)]
        public MyObjectBuilder_EdgesDefinition[] Edges;
        [XmlArrayItem("EmissiveColor"), ProtoMember(270)]
        public MyObjectBuilder_EmissiveColorDefinition[] EmissiveColors;
        [XmlArrayItem("EmissiveColorStatePreset"), ProtoMember(0x112)]
        public MyObjectBuilder_EmissiveColorStatePresetDefinition[] EmissiveColorStatePresets;
        [ProtoMember(0x14d), XmlArrayItem("EntityComponent", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ComponentDefinitionBase>))]
        public MyObjectBuilder_ComponentDefinitionBase[] EntityComponents;
        [ProtoMember(0x151), XmlArrayItem("Container", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ContainerDefinition>))]
        public MyObjectBuilder_ContainerDefinition[] EntityContainers;
        [XmlArrayItem("Group"), ProtoMember(0x13a)]
        public MyGroupedIds[] EnvironmentGroups;
        [ProtoMember(0x6f), XmlArrayItem("EnvironmentItem", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_EnvironmentItemDefinition>))]
        public MyObjectBuilder_EnvironmentItemDefinition[] EnvironmentItems;
        [XmlArrayItem("Definition", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_EnvironmentItemsDefinition>)), ProtoMember(0xf3)]
        public MyObjectBuilder_EnvironmentItemsDefinition[] EnvironmentItemsDefinitions;
        [XmlArrayItem("Entry"), ProtoMember(0xf7)]
        public EnvironmentItemsEntry[] EnvironmentItemsEntries;
        [ProtoMember(50), XmlElement("Environment", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_EnvironmentDefinition>))]
        public MyObjectBuilder_EnvironmentDefinition[] Environments;
        [XmlArrayItem("Faction", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_FactionDefinition>)), ProtoMember(0x5f)]
        public MyObjectBuilder_FactionDefinition[] Factions;
        [XmlArrayItem("Definition", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_FlareDefinition>)), ProtoMember(0x15c)]
        public MyObjectBuilder_FlareDefinition[] Flares;
        [ProtoMember(0x11a), XmlArrayItem("Definition", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_FloraElementDefinition>))]
        public MyObjectBuilder_FloraElementDefinition[] FloraElements;
        [ProtoMember(0x159), XmlArrayItem("Font", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_FontDefinition>))]
        public MyObjectBuilder_FontDefinition[] Fonts;
        [ProtoMember(290), XmlArrayItem("Gas")]
        public MyObjectBuilder_GasProperties[] GasProperties;
        [ProtoMember(0x37), XmlArrayItem("GlobalEvent", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_GlobalEventDefinition>))]
        public MyObjectBuilder_GlobalEventDefinition[] GlobalEvents;
        [XmlArrayItem("GridCreator"), ProtoMember(0x13)]
        public MyObjectBuilder_GridCreateToolDefinition[] GridCreators;
        [ProtoMember(0x3b), XmlArrayItem("HandItem", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_HandItemDefinition>))]
        public MyObjectBuilder_HandItemDefinition[] HandItems;
        [XmlArrayItem("LCDTextureDefinition", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_LCDTextureDefinition>)), ProtoMember(0xc7)]
        public MyObjectBuilder_LCDTextureDefinition[] LCDTextures;
        [XmlArrayItem("MainMenuInventoryScene", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_MainMenuInventorySceneDefinition>)), ProtoMember(0x9b)]
        public MyObjectBuilder_MainMenuInventorySceneDefinition[] MainMenuInventoryScenes;
        [XmlArrayItem("Properties", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_MaterialPropertiesDefinition>)), ProtoMember(0xe3)]
        public MyObjectBuilder_MaterialPropertiesDefinition[] MaterialProperties;
        [XmlArrayItem("MultiBlock", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_MultiBlockDefinition>)), ProtoMember(0xa3)]
        public MyObjectBuilder_MultiBlockDefinition[] MultiBlocks;
        [XmlArrayItem("ParticleEffect", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ParticleEffect>)), ProtoMember(0xbb)]
        public MyObjectBuilder_ParticleEffect[] ParticleEffects;
        [ProtoMember(0x3f), XmlArrayItem("PhysicalItem", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_PhysicalItemDefinition>))]
        public MyObjectBuilder_PhysicalItemDefinition[] PhysicalItems;
        [ProtoMember(0xd3), XmlArrayItem("PhysicalMaterial", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_PhysicalMaterialDefinition>))]
        public MyObjectBuilder_PhysicalMaterialDefinition[] PhysicalMaterials;
        [ProtoMember(0x146), XmlArrayItem("Antenna", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_PirateAntennaDefinition>))]
        public MyObjectBuilder_PirateAntennaDefinition[] PirateAntennas;
        [XmlArrayItem("PlanetGeneratorDefinition", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_PlanetGeneratorDefinition>)), ProtoMember(0x116)]
        public MyObjectBuilder_PlanetGeneratorDefinition[] PlanetGeneratorDefinitions;
        [XmlArrayItem("PlanetPrefab", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_PlanetPrefabDefinition>)), ProtoMember(310)]
        public MyObjectBuilder_PlanetPrefabDefinition[] PlanetPrefabs;
        [XmlArrayItem("Prefab", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_PrefabDefinition>)), ProtoMember(0x63)]
        public MyObjectBuilder_PrefabDefinition[] Prefabs;
        [XmlArrayItem("PrefabThrower", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_PrefabThrowerDefinition>)), ProtoMember(0xa7)]
        public MyObjectBuilder_PrefabThrowerDefinition[] PrefabThrowers;
        [XmlArrayItem("DistributionGroup"), ProtoMember(0x126)]
        public MyObjectBuilder_ResourceDistributionGroup[] ResourceDistributionGroups;
        [XmlArrayItem("Ship", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_RespawnShipDefinition>)), ProtoMember(0x77)]
        public MyObjectBuilder_RespawnShipDefinition[] RespawnShips;
        [XmlArrayItem("Rope", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_RopeDefinition>)), ProtoMember(0xcf)]
        public MyObjectBuilder_RopeDefinition[] RopeTypes;
        [ProtoMember(0x13e), XmlArrayItem("Group", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ScriptedGroupDefinition>))]
        public MyObjectBuilder_ScriptedGroupDefinition[] ScriptedGroups;
        [ProtoMember(0x142), XmlArrayItem("Map")]
        public MyMappedId[] ScriptedGroupsMap;
        [ProtoMember(340), XmlArrayItem("ShadowTextureSet")]
        public MyObjectBuilder_ShadowTextureSetDefinition[] ShadowTextureSets;
        [XmlArrayItem("ShipBlueprint", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ShipBlueprintDefinition>)), ProtoMember(0x87)]
        public MyObjectBuilder_ShipBlueprintDefinition[] ShipBlueprints;
        [ProtoMember(0xaf), XmlArrayItem("ShipSoundGroup", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ShipSoundsDefinition>))]
        public MyObjectBuilder_ShipSoundsDefinition[] ShipSoundGroups;
        [XmlElement("ShipSoundSystem", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ShipSoundSystemDefinition>)), ProtoMember(0xb7)]
        public MyObjectBuilder_ShipSoundSystemDefinition ShipSoundSystem;
        [ProtoMember(0xab), XmlArrayItem("SoundCategory", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_SoundCategoryDefinition>))]
        public MyObjectBuilder_SoundCategoryDefinition[] SoundCategories;
        [XmlArrayItem("Sound", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_AudioDefinition>)), ProtoMember(0x93)]
        public MyObjectBuilder_AudioDefinition[] Sounds;
        [XmlArrayItem("SpawnGroup", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_SpawnGroupDefinition>)), ProtoMember(0x43)]
        public MyObjectBuilder_SpawnGroupDefinition[] SpawnGroups;
        [XmlArrayItem("Stat"), ProtoMember(0x11e)]
        public MyObjectBuilder_EntityStatDefinition[] StatDefinitions;
        [ProtoMember(0x47), XmlArrayItem("TransparentMaterial", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_TransparentMaterialDefinition>))]
        public MyObjectBuilder_TransparentMaterialDefinition[] TransparentMaterials;
        [ProtoMember(0x9f), XmlArrayItem("VoxelHand", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_VoxelHandDefinition>))]
        public MyObjectBuilder_VoxelHandDefinition[] VoxelHands;
        [ProtoMember(0xc3), XmlArrayItem("VoxelMapStorage", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_VoxelMapStorageDefinition>))]
        public MyObjectBuilder_VoxelMapStorageDefinition[] VoxelMapStorages;
        [ProtoMember(0x4b), XmlArrayItem("VoxelMaterial", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_VoxelMaterialDefinition>))]
        public MyObjectBuilder_VoxelMaterialDefinition[] VoxelMaterials;
        [XmlArrayItem("Weapon", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_WeaponDefinition>)), ProtoMember(0x8b)]
        public MyObjectBuilder_WeaponDefinition[] Weapons;
        [XmlArrayItem("WheelModel", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_WheelModelsDefinition>)), ProtoMember(0x7f)]
        public MyObjectBuilder_WheelModelsDefinition[] WheelModels;
    }
}


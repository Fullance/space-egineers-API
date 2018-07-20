namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game.ObjectBuilders;
    using VRage.ObjectBuilders;
    using VRage.ObjectBuilders.Definitions.Components;

    [ProtoContract, XmlType("PlanetGeneratorDefinition"), XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_PlanetGeneratorDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x275)]
        public MyPlanetAnimalSpawnInfo AnimalSpawnInfo;
        [ProtoMember(0x253)]
        public MyPlanetAtmosphere Atmosphere;
        [ProtoMember(0x256)]
        public MyAtmosphereSettings? AtmosphereSettings;
        [ProtoMember(0x22f), XmlArrayItem("CloudLayer")]
        public List<MyCloudLayerSettings> CloudLayers;
        [ProtoMember(0x25c)]
        public MyPlanetMaterialGroup[] ComplexMaterials;
        [XmlArrayItem("Material"), ProtoMember(0x242)]
        public MyPlanetMaterialDefinition[] CustomMaterialTable;
        [ProtoMember(0x24d)]
        public MyPlanetMaterialDefinition DefaultSubSurfaceMaterial;
        [ProtoMember(0x24a)]
        public MyPlanetMaterialDefinition DefaultSurfaceMaterial;
        [XmlArrayItem("Distortion"), ProtoMember(0x246)]
        public MyPlanetDistortionDefinition[] DistortionTable;
        public SerializableDefinitionId? Environment;
        [ProtoMember(0x26b), XmlArrayItem("Item")]
        public PlanetEnvironmentItemMapping[] EnvironmentItems;
        [ProtoMember(0x259)]
        public string FolderName;
        [ProtoMember(0x236)]
        public float? GravityFalloffPower;
        [ProtoMember(0x22c)]
        public bool? HasAtmosphere;
        [ProtoMember(0x233)]
        public SerializableRange? HillParams;
        [ProtoMember(0x23f)]
        public MyAtmosphereColorShift HostileAtmosphereColorShift;
        [ProtoMember(0x27d)]
        public string InheritFrom;
        [XmlElement(typeof(MyAbstractXmlSerializer<MyObjectBuilder_PlanetMapProvider>))]
        public MyObjectBuilder_PlanetMapProvider MapProvider;
        [ProtoMember(0x26f)]
        public MyPlanetMaterialBlendSettings? MaterialBlending;
        [ProtoMember(0x239)]
        public SerializableRange? MaterialsMaxDepth;
        [ProtoMember(0x23c)]
        public SerializableRange? MaterialsMinDepth;
        [ProtoMember(0x285)]
        public MyObjectBuilder_VoxelMesherComponentDefinition MesherPostprocessing;
        [XmlArrayItem("MusicCategory"), ProtoMember(0x263)]
        public List<MyMusicCategory> MusicCategories;
        [ProtoMember(0x278)]
        public MyPlanetAnimalSpawnInfo NightAnimalSpawnInfo;
        [XmlArrayItem("Ore"), ProtoMember(0x267)]
        public MyPlanetOreMapping[] OreMappings;
        [ProtoMember(0x229)]
        public MyPlanetMaps? PlanetMaps;
        public float? SectorDensity;
        [XmlArrayItem("SoundRule"), ProtoMember(0x25f)]
        public MySerializablePlanetEnvironmentalSoundRule[] SoundRules;
        [ProtoMember(0x272)]
        public MyPlanetSurfaceDetail SurfaceDetail;
        [ProtoMember(0x250)]
        public float? SurfaceGravity;
    }
}


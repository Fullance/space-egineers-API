namespace VRage.Game.ObjectBuilders.Definitions.SessionComponents
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game.ObjectBuilders.Definitions;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CubeBuilderDefinition : MyObjectBuilder_SessionComponentDefinition
    {
        public double BuildingDistLargeSurvivalCharacter = 10.0;
        public double BuildingDistLargeSurvivalShip = 12.5;
        public double BuildingDistSmallSurvivalCharacter = 5.0;
        public double BuildingDistSmallSurvivalShip = 12.5;
        public MyPlacementSettings BuildingSettings;
        public float DefaultBlockBuildingDistance = 20f;
        public float MaxBlockBuildingDistance = 20f;
        public float MinBlockBuildingDistance = 1f;
    }
}


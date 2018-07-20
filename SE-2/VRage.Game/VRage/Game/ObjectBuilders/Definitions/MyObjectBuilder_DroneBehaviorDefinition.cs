namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_DroneBehaviorDefinition : MyObjectBuilder_DefinitionBase
    {
        public string AlternativeBehavior = "";
        public bool AvoidCollisions = true;
        public bool CanBeDisabled = true;
        public int LostTimeMs = 0x4e20;
        public float MaxManeuverDistance = 250f;
        public float MinStrafeDistance = 2f;
        public float PlanetHoverMax = 25f;
        public float PlanetHoverMin = 2f;
        public float PlayerYAxisOffset = 0.9f;
        public float RammingBehaviorDistance = 75f;
        public bool RotateToPlayer = true;
        public string SoundLoop = "";
        public float SpeedLimit = 50f;
        public float StaticWeaponryUsage = 300f;
        public float StrafeDepth = 5f;
        public float StrafeHeight = 10f;
        public float StrafeWidth = 10f;
        public float TargetDistance = 200f;
        public float ToolsUsage = 8f;
        public bool UsePlanetHover;
        public bool UseRammingBehavior;
        public bool UseStaticWeaponry = true;
        public bool UsesWeaponBehaviors;
        public bool UseTools = true;
        public int WaypointDelayMsMax = 0xbb8;
        public int WaypointDelayMsMin = 0x3e8;
        public int WaypointMaxTime = 0x3a98;
        public float WaypointThresholdDistance = 0.5f;
        public float WeaponBehaviorNotFoundDelay = 3f;
        [XmlArrayItem("WeaponBehavior")]
        public List<MyWeaponBehavior> WeaponBehaviors;
    }
}


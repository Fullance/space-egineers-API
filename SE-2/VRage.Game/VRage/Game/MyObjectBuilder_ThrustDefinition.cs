namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ThrustDefinition : MyObjectBuilder_CubeBlockDefinition
    {
        [ProtoMember(90)]
        public float ConsumptionFactorPerG;
        private static readonly Vector4 DefaultThrustColor = new Vector4((Vector3) (Color.CornflowerBlue.ToVector3() * 0.7f), 0.75f);
        [ProtoMember(0x51)]
        public float EffectivenessAtMaxInfluence = 1f;
        [ProtoMember(0x54)]
        public float EffectivenessAtMinInfluence = 1f;
        [ProtoMember(0x48)]
        public float FlameDamage = 0.5f;
        [ProtoMember(0x2d)]
        public float FlameDamageLengthScale = 0.6f;
        [ProtoMember(0x3f)]
        public string FlameFlare = "SmallGridSmallThruster";
        [ProtoMember(0x33)]
        public Vector4 FlameFullColor = DefaultThrustColor;
        [ProtoMember(0x45)]
        public float FlameGlareQuerySize = 0.5f;
        [ProtoMember(0x36)]
        public Vector4 FlameIdleColor = DefaultThrustColor;
        [ProtoMember(60)]
        public string FlameLengthMaterial = "EngineThrustMiddle";
        [ProtoMember(0x30)]
        public float FlameLengthScale = 1.15f;
        [ProtoMember(0x39)]
        public string FlamePointMaterial = "EngineThrustMiddle";
        [ProtoMember(0x42)]
        public float FlameVisibilityDistance = 200f;
        [ProtoMember(0x24)]
        public float ForceMagnitude;
        [ProtoMember(0x1b)]
        public MyFuelConverterInfo FuelConverter = new MyFuelConverterInfo();
        [ProtoMember(0x4e)]
        public float MaxPlanetaryInfluence = 1f;
        [ProtoMember(0x27)]
        public float MaxPowerConsumption;
        [ProtoMember(0x4b)]
        public float MinPlanetaryInfluence;
        [ProtoMember(0x2a)]
        public float MinPowerConsumption;
        [ProtoMember(0x57)]
        public bool NeedsAtmosphereForInfluence;
        [ProtoMember(0x69)]
        public float PropellerAccelerationTime = 3f;
        [ProtoMember(0x6c)]
        public float PropellerDecelerationTime = 6f;
        [ProtoMember(0x6f)]
        public float PropellerMaxVisibleDistance = 20f;
        [ProtoMember(0x63)]
        public float PropellerRoundsPerSecondOnFullSpeed = 1.9f;
        [ProtoMember(0x66)]
        public float PropellerRoundsPerSecondOnIdleSpeed = 0.3f;
        [ProtoMember(0x60)]
        public string PropellerSubpartEntityName = "Propeller";
        [ProtoMember(0x5d)]
        public bool PropellerUsesPropellerSystem;
        [ProtoMember(0x18)]
        public string ResourceSinkGroup;
        [ProtoMember(30)]
        public float SlowdownFactor = 10f;
        [ProtoMember(0x21)]
        public string ThrusterType = "Ion";
    }
}


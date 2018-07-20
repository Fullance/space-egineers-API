namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ProductionBlockDefinition : MyObjectBuilder_CubeBlockDefinition
    {
        [XmlArrayItem("Class"), ProtoMember(0x1c)]
        public string[] BlueprintClasses;
        [ProtoMember(13)]
        public float InventoryMaxVolume;
        [ProtoMember(0x10)]
        public Vector3 InventorySize;
        [ProtoMember(0x19)]
        public float OperationalPowerConsumption;
        [ProtoMember(0x13)]
        public string ResourceSinkGroup;
        [ProtoMember(0x16)]
        public float StandbyPowerConsumption;
    }
}


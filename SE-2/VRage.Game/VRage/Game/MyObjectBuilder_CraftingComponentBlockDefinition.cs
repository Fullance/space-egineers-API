namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_CraftingComponentBlockDefinition : MyObjectBuilder_ComponentDefinitionBase
    {
        [ProtoMember(0x13), XmlArrayItem("OperatingItem")]
        public SerializableDefinitionId[] AcceptedOperatingItems = new SerializableDefinitionId[0];
        [ProtoMember(13)]
        public string AvailableBlueprintClasses;
        [ProtoMember(0x10)]
        public float CraftingSpeedMultiplier = 1f;
    }
}


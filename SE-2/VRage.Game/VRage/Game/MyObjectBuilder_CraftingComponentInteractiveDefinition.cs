namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_CraftingComponentInteractiveDefinition : MyObjectBuilder_ComponentDefinitionBase
    {
        [ProtoMember(15)]
        public string ActionSound;
        [ProtoMember(12)]
        public string AvailableBlueprintClasses;
        [ProtoMember(0x12)]
        public float CraftingSpeedMultiplier = 1f;
    }
}


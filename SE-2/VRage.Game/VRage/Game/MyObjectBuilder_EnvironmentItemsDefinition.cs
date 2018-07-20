namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EnvironmentItemsDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(11)]
        public int Channel;
        [ProtoMember(0x17)]
        public float ItemSize;
        [ProtoMember(14)]
        public float MaxViewDistance;
        [ProtoMember(20)]
        public string PhysicalMaterial;
        [ProtoMember(0x11)]
        public float SectorSize;
    }
}


namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ResourceDistributionGroup : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x11)]
        public bool IsAdaptible;
        [ProtoMember(14)]
        public bool IsSource;
        [ProtoMember(11)]
        public int Priority;
    }
}


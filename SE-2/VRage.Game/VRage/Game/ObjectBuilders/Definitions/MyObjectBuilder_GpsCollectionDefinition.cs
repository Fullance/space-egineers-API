namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_GpsCollectionDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x13), XmlArrayItem("Position")]
        public string[] Positions;
    }
}


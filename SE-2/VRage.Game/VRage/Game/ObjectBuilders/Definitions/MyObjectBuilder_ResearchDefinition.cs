namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), XmlType("ResearchDefinition")]
    public class MyObjectBuilder_ResearchDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlElement("Entry"), ProtoMember(0x11)]
        public List<SerializableDefinitionId> Entries;
    }
}


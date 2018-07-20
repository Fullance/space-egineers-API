namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_SessionComponentResearchDefinition : MyObjectBuilder_SessionComponentDefinition
    {
        [XmlElement("Research")]
        public List<SerializableDefinitionId> Researches;
        public bool WhitelistMode;
    }
}


namespace VRage.Game.ObjectBuilders.Components
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_SessionComponentResearch : MyObjectBuilder_SessionComponent
    {
        public bool DeserializeRequiredResearches;
        [XmlElement("RequiredResearch")]
        public List<SerializableDefinitionId> RequiredResearches;
        [XmlElement("Research")]
        public List<ResearchData> Researches;
        public bool WhitelistMode;

        [StructLayout(LayoutKind.Sequential)]
        public struct ResearchData
        {
            [XmlAttribute("Identity")]
            public long IdentityId;
            [XmlElement("Entry")]
            public List<SerializableDefinitionId> Definitions;
        }
    }
}


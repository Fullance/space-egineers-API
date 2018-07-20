namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EntityStatComponentDefinition : MyObjectBuilder_ComponentDefinitionBase
    {
        [XmlArrayItem("Script"), ProtoMember(0x12)]
        public List<string> Scripts;
        [XmlArrayItem("Stat"), ProtoMember(14)]
        public List<SerializableDefinitionId> Stats;
    }
}


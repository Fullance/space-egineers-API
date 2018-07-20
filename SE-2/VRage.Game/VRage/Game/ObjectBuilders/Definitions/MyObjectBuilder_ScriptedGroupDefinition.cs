namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ScriptedGroupDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(11)]
        public string Category;
        [ProtoMember(14)]
        public string Script;
    }
}


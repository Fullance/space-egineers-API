namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), XmlRoot("ScenarioDefinitions"), ProtoContract]
    public class MyObjectBuilder_ScenarioDefinitions : MyObjectBuilder_Base
    {
        [ProtoMember(14), XmlArrayItem("ScenarioDefinition")]
        public MyObjectBuilder_ScenarioDefinition[] Scenarios;
    }
}


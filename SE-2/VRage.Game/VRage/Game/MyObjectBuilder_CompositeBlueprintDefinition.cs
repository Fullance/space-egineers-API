namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CompositeBlueprintDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlArrayItem("Blueprint"), ProtoMember(12)]
        public BlueprintItem[] Blueprints;
    }
}


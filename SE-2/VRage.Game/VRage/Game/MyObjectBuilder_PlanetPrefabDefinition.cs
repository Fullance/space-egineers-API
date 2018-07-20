namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_PlanetPrefabDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(11)]
        public MyObjectBuilder_Planet PlanetBuilder;
    }
}


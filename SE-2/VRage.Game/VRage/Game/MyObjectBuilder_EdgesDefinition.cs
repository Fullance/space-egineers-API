namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EdgesDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x23)]
        public MyEdgesModelSet Large;
        [ProtoMember(0x20)]
        public MyEdgesModelSet Small;
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_EmissiveColorDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(13)]
        public RGBAColor ColorDefinition;
    }
}


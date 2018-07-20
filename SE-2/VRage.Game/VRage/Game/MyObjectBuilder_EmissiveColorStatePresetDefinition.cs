namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((System.Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EmissiveColorStatePresetDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlArrayItem("EmissiveState"), ProtoMember(14)]
        public EmissiveStateDefinition[] EmissiveStates;
    }
}


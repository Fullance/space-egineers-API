namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_RespawnShipDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(14)]
        public int CooldownSeconds;
        [ProtoMember(11)]
        public string Prefab;
    }
}


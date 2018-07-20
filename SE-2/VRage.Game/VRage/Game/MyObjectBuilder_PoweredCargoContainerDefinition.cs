namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_PoweredCargoContainerDefinition : MyObjectBuilder_CargoContainerDefinition
    {
        [ProtoMember(14)]
        public float RequiredPowerInput;
        [ProtoMember(11)]
        public string ResourceSinkGroup;
    }
}


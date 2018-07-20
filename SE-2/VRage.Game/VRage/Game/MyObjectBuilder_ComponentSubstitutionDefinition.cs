namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_ComponentSubstitutionDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x1a), XmlArrayItem("ProvidingComponent")]
        public ProvidingComponent[] ProvidingComponents;
        [ProtoMember(0x16)]
        public SerializableDefinitionId RequiredComponentId;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct ProvidingComponent
        {
            [ProtoMember(15)]
            public SerializableDefinitionId Id;
            [ProtoMember(0x12)]
            public int Amount;
        }
    }
}


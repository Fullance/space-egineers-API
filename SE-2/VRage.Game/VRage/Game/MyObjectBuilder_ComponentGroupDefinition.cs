namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ComponentGroupDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlArrayItem("Component"), ProtoMember(0x19)]
        public Component[] Components;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct Component
        {
            [XmlAttribute, ProtoMember(15)]
            public string SubtypeId;
            [XmlAttribute, ProtoMember(0x13)]
            public int Amount;
        }
    }
}


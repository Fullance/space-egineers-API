namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((System.Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_DebrisDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x19)]
        public float MinAmount;
        [ModdableContentFile("mwm"), ProtoMember(0x12)]
        public string Model;
        [ProtoMember(0x16)]
        public MyDebrisType Type;
    }
}


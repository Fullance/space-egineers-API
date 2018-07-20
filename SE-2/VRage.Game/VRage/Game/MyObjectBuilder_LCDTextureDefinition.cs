namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_LCDTextureDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x10, IsRequired=false)]
        public string LocalizationId;
        [ModdableContentFile("dds"), ProtoMember(12)]
        public string TexturePath;
    }
}


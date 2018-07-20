namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_SoundCategoryDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x16)]
        public SoundDesc[] Sounds;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct SoundDesc
        {
            [XmlAttribute]
            public string Id;
            [XmlAttribute]
            public string SoundName;
        }
    }
}


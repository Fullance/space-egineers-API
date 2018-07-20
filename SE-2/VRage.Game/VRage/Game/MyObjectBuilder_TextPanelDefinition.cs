namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_TextPanelDefinition : MyObjectBuilder_CubeBlockDefinition
    {
        public float MaxChangingSpeed = 30f;
        public float MaxFontSize = 10f;
        public float MinFontSize = 0.1f;
        [ProtoMember(14)]
        public float RequiredPowerInput = 0.001f;
        [ProtoMember(11)]
        public string ResourceSinkGroup;
        [ProtoMember(20)]
        public int TextureAspectRadio = 1;
        [ProtoMember(0x11)]
        public int TextureResolution = 0x200;
    }
}


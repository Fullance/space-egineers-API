namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_RopeDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x17)]
        public string AddMapsTexture;
        [ProtoMember(0x1a)]
        public string AttachSound;
        [ProtoMember(0x11)]
        public string ColorMetalTexture;
        [ProtoMember(0x1d)]
        public string DetachSound;
        [ProtoMember(11)]
        public bool EnableRayCastRelease;
        [ProtoMember(14)]
        public bool IsDefaultCreativeRope;
        [ProtoMember(20)]
        public string NormalGlossTexture;
        [ProtoMember(0x20)]
        public string WindingSound;
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_DoorDefinition : MyObjectBuilder_CubeBlockDefinition
    {
        [ProtoMember(20)]
        public string CloseSound;
        [ProtoMember(14)]
        public float MaxOpen;
        [ProtoMember(0x17)]
        public float OpeningSpeed = 1f;
        [ProtoMember(0x11)]
        public string OpenSound;
        [ProtoMember(11)]
        public string ResourceSinkGroup;
    }
}


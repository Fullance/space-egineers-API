namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ProjectorDefinition : MyObjectBuilder_CubeBlockDefinition
    {
        [ProtoMember(15)]
        public string IdleSound;
        [ProtoMember(13)]
        public float RequiredPowerInput;
        [ProtoMember(11)]
        public string ResourceSinkGroup;
    }
}


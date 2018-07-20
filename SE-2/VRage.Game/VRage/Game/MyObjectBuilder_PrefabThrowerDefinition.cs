namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_PrefabThrowerDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(11)]
        public float? Mass = null;
        [ProtoMember(14)]
        public float MaxSpeed = 80f;
        [ProtoMember(0x11)]
        public float MinSpeed = 1f;
        [ProtoMember(0x17)]
        public string PrefabToThrow;
        [ProtoMember(20)]
        public float PushTime = 1f;
        [ProtoMember(0x1a)]
        public string ThrowSound;
    }
}


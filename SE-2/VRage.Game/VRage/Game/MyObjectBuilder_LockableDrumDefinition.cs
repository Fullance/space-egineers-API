namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_LockableDrumDefinition : MyObjectBuilder_CubeBlockDefinition
    {
        [ProtoMember(3)]
        public float DefaultMaxRopeLength;
        [ProtoMember(2)]
        public float MaxCustomRopeLength;
        [ProtoMember(1)]
        public float MinCustomRopeLength;
    }
}


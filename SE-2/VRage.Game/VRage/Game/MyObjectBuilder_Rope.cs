namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Rope : MyObjectBuilder_EntityBase
    {
        [ProtoMember(0x11)]
        public float CurrentRopeLength;
        [ProtoMember(20)]
        public long EntityIdHookA;
        [ProtoMember(0x17)]
        public long EntityIdHookB;
        [ProtoMember(14)]
        public float MaxRopeLength;
    }
}


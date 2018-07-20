namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ManipulationTool : MyObjectBuilder_EntityBase
    {
        [ProtoMember(0x15)]
        public SerializableQuaternion HeadLocalPivotOrientation = Quaternion.Identity;
        [ProtoMember(0x12)]
        public SerializableVector3 HeadLocalPivotPosition = Vector3.Zero;
        [ProtoMember(15)]
        public long OtherEntityId;
        [ProtoMember(0x1b)]
        public SerializableQuaternion OtherLocalPivotOrientation = Quaternion.Identity;
        [ProtoMember(0x18)]
        public SerializableVector3 OtherLocalPivotPosition = Vector3.Zero;
        [ProtoMember(12)]
        public byte State;
    }
}


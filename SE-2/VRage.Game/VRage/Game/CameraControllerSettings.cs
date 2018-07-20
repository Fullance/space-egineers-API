namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class CameraControllerSettings
    {
        [ProtoMember(0x11)]
        public double Distance;
        [XmlAttribute]
        public long EntityId;
        [ProtoMember(20)]
        public SerializableVector2? HeadAngle;
        [ProtoMember(14)]
        public bool IsFirstPerson;
    }
}


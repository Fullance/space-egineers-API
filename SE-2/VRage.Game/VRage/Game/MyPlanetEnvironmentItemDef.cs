namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRageMath;

    [ProtoContract]
    public class MyPlanetEnvironmentItemDef
    {
        [ProtoMember(0x1d3)]
        public Vector3 BaseColor = Vector3.Zero;
        [ProtoMember(470)]
        public Vector2 ColorSpread = Vector2.Zero;
        [XmlAttribute(AttributeName="Density"), ProtoMember(0x1cb)]
        public float Density;
        [XmlAttribute(AttributeName="GroupId"), ProtoMember(0x1bd)]
        public string GroupId;
        [ProtoMember(0x1c5)]
        public int GroupIndex = -1;
        [XmlAttribute(AttributeName="IsDetail"), ProtoMember(0x1cf)]
        public bool IsDetail;
        [XmlAttribute(AttributeName="MaxRoll"), ProtoMember(0x1dd)]
        public float MaxRoll;
        [ProtoMember(0x1c1), XmlAttribute(AttributeName="ModifierId")]
        public string ModifierId;
        [ProtoMember(0x1c8)]
        public int ModifierIndex = -1;
        [XmlAttribute(AttributeName="Offset"), ProtoMember(0x1d9)]
        public float Offset;
        [ProtoMember(0x1b9), XmlAttribute(AttributeName="SubtypeId")]
        public string SubtypeId;
        [XmlAttribute(AttributeName="TypeId"), ProtoMember(0x1b5)]
        public string TypeId;
    }
}


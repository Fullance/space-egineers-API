namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class CutsceneSequenceNodeWaypoint
    {
        [ProtoMember(0xb8), XmlAttribute]
        public string Name = "";
        [XmlAttribute, ProtoMember(0xbc)]
        public float Time;
    }
}


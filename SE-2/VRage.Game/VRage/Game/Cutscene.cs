namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [ProtoContract]
    public class Cutscene
    {
        [ProtoMember(40)]
        public bool CanBeSkipped = true;
        [ProtoMember(0x2b)]
        public bool FireEventsDuringSkip = true;
        [ProtoMember(0x19)]
        public string Name = "";
        [ProtoMember(0x22)]
        public string NextCutscene = "";
        [ProtoMember(0x2e), XmlArrayItem("Node")]
        public List<CutsceneSequenceNode> SequenceNodes;
        [ProtoMember(0x1c)]
        public string StartEntity = "";
        [ProtoMember(0x25)]
        public float StartingFOV = 70f;
        [ProtoMember(0x1f)]
        public string StartLookAt = "";
    }
}


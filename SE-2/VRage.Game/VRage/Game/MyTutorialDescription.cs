namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyTutorialDescription
    {
        [ProtoMember(10)]
        public string Name;
        [XmlArrayItem("Tutorial"), ProtoMember(13)]
        public string[] UnlockedBy;
    }
}


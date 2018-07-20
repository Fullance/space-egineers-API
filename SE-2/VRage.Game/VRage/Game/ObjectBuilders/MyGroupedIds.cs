namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.Utils;

    [ProtoContract]
    public class MyGroupedIds
    {
        [XmlArrayItem("GroupEntry"), ProtoMember(30), DefaultValue((string) null)]
        public GroupedId[] Entries;
        [ProtoMember(0x1b), XmlAttribute]
        public string Tag;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct GroupedId
        {
            [XmlAttribute, ProtoMember(14)]
            public string TypeId;
            [XmlAttribute, ProtoMember(0x11)]
            public string SubtypeName;
            [XmlIgnore]
            public MyStringHash SubtypeId =>
                MyStringHash.GetOrCompute(this.SubtypeName);
        }
    }
}


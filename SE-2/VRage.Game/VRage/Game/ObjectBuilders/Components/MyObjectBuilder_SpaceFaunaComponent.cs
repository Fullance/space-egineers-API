namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_SpaceFaunaComponent : MyObjectBuilder_SessionComponent
    {
        [XmlArrayItem("Info"), ProtoMember(0x3a)]
        public List<SpawnInfo> SpawnInfos = new List<SpawnInfo>();
        [XmlArrayItem("Info"), ProtoMember(0x3e)]
        public List<TimeoutInfo> TimeoutInfos = new List<TimeoutInfo>();

        [ProtoContract]
        public class SpawnInfo
        {
            [XmlAttribute("A"), ProtoMember(0x20)]
            public int AbandonTime;
            [ProtoMember(0x1c), XmlAttribute("S")]
            public int SpawnTime;
            [XmlAttribute, ProtoMember(0x10)]
            public double X;
            [ProtoMember(20), XmlAttribute]
            public double Y;
            [XmlAttribute, ProtoMember(0x18)]
            public double Z;
        }

        [ProtoContract]
        public class TimeoutInfo
        {
            [XmlAttribute("T"), ProtoMember(0x34)]
            public int Timeout;
            [XmlAttribute, ProtoMember(40)]
            public double X;
            [XmlAttribute, ProtoMember(0x2c)]
            public double Y;
            [ProtoMember(0x30), XmlAttribute]
            public double Z;
        }
    }
}


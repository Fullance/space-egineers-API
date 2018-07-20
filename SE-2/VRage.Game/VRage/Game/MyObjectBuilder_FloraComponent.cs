namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_FloraComponent : MyObjectBuilder_SessionComponent
    {
        [XmlArrayItem("Item"), ProtoMember(0x21)]
        public HarvestedData[] DecayItems = new HarvestedData[0];
        [ProtoMember(0x1d)]
        public List<HarvestedData> HarvestedItems = new List<HarvestedData>();

        [ProtoContract]
        public class HarvestedData
        {
            [ProtoMember(0x10), XmlAttribute]
            public string GroupName;
            [ProtoMember(20), XmlAttribute]
            public int LocalId;
            [XmlAttribute, ProtoMember(0x18)]
            public double Timer;
        }
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlType("SetupBasePrefab")]
    public class MyObjectBuilder_WorldGeneratorOperation_SetupBasePrefab : MyObjectBuilder_WorldGeneratorOperation
    {
        [XmlAttribute, ProtoMember(0xfc)]
        public string AsteroidName;
        [XmlAttribute, ProtoMember(0xff)]
        public string BeaconName;
        [ProtoMember(0xf8)]
        public SerializableVector3 Offset;
        [ProtoMember(0xf5), XmlAttribute]
        public string PrefabFile;

        public bool ShouldSerializeBeaconName() => 
            !string.IsNullOrEmpty(this.BeaconName);

        public bool ShouldSerializeOffset() => 
            (this.Offset != new SerializableVector3(0f, 0f, 0f));
    }
}


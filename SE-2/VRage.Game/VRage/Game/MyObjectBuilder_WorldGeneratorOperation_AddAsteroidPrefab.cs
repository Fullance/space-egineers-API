namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [XmlType("AddAsteroidPrefab"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_WorldGeneratorOperation_AddAsteroidPrefab : MyObjectBuilder_WorldGeneratorOperation
    {
        [XmlAttribute, ProtoMember(0xd0)]
        public string Name;
        [ProtoMember(0xd3)]
        public SerializableVector3 Position;
        [ProtoMember(0xcd), XmlAttribute]
        public string PrefabFile;
    }
}


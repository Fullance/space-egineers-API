namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlType("AddPlanetPrefab")]
    public class MyObjectBuilder_WorldGeneratorOperation_AddPlanetPrefab : MyObjectBuilder_WorldGeneratorOperation
    {
        [XmlAttribute, ProtoMember(0x10f)]
        public bool AddGPS;
        [XmlAttribute, ProtoMember(0x10c)]
        public string DefinitionName;
        [ProtoMember(0x112)]
        public SerializableVector3D Position;
        [XmlAttribute, ProtoMember(0x109)]
        public string PrefabName;
    }
}


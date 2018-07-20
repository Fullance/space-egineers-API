namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlType("AddObjectsPrefab"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_WorldGeneratorOperation_AddObjectsPrefab : MyObjectBuilder_WorldGeneratorOperation
    {
        [XmlAttribute, ProtoMember(0xdb)]
        public string PrefabFile;
    }
}


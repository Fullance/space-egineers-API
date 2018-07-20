namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_PirateAntennaDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x15)]
        public int FirstSpawnTimeMs;
        [ProtoMember(0x18)]
        public int MaxDrones;
        [ProtoMember(12)]
        public string Name;
        [ProtoMember(15)]
        public float SpawnDistance;
        [XmlArrayItem("Group"), ProtoMember(0x1c)]
        public string[] SpawnGroups;
        [ProtoMember(0x12)]
        public int SpawnTimeMs;
    }
}


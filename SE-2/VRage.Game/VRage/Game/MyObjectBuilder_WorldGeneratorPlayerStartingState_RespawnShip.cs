namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlType("RespawnShip")]
    public class MyObjectBuilder_WorldGeneratorPlayerStartingState_RespawnShip : MyObjectBuilder_WorldGeneratorPlayerStartingState
    {
        [ProtoMember(0xba), XmlAttribute]
        public bool DampenersEnabled;
        [ProtoMember(0xbd), XmlAttribute]
        public string RespawnShip;
    }
}


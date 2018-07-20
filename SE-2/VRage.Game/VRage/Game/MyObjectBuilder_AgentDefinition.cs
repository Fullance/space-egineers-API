namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_AgentDefinition : MyObjectBuilder_BotDefinition
    {
        [ProtoMember(12)]
        public string BotModel = "";
        [ProtoMember(0x21)]
        public string FactionTag;
        [ProtoMember(0x15)]
        public SerializableDefinitionId? InventoryContainerTypeId;
        [ProtoMember(0x12)]
        public bool InventoryContentGenerated;
        [ProtoMember(0x18)]
        public bool RemoveAfterDeath = true;
        [ProtoMember(30)]
        public int RemoveTimeMs = 0x7530;
        [ProtoMember(0x1b)]
        public int RespawnTimeMs = 0x2710;
        [ProtoMember(15), DefaultValue("")]
        public string TargetType = "";
    }
}


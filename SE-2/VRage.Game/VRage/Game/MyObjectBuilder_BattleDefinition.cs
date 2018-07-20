namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_BattleDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x19), XmlArrayItem("Blueprint"), DefaultValue((string) null)]
        public string[] DefaultBlueprints;
        [ProtoMember(13)]
        public MyObjectBuilder_Toolbar DefaultToolbar;
        [ProtoMember(0x15), DefaultValue((float) 0.067f)]
        public float DefenderEntityDamage = 0.067f;
        [DefaultValue((string) null), XmlArrayItem("Block"), ProtoMember(0x11)]
        public SerializableDefinitionId[] SpawnBlocks;
    }
}


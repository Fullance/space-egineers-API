namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_GhostCharacterDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x12), XmlArrayItem("WeaponId")]
        public SerializableDefinitionId[] LeftHandWeapons;
        [ProtoMember(0x16), XmlArrayItem("WeaponId")]
        public SerializableDefinitionId[] RightHandWeapons;
    }
}


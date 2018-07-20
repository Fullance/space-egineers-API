namespace VRage.Game.ObjectBuilders.Gui
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;
    using VRageMath;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ServerFilterOptions : MyObjectBuilder_Base
    {
        [ProtoMember(0x37)]
        public bool Advanced;
        [ProtoMember(0x13)]
        public bool AllowedGroups;
        [ProtoMember(0x31)]
        public bool CheckDistance;
        [ProtoMember(0x2b)]
        public bool CheckMod;
        [ProtoMember(0x25)]
        public bool CheckPlayer;
        [ProtoMember(0x1f)]
        public bool CreativeMode;
        [ProtoMember(0x43)]
        public SerializableDictionary<byte, string> Filters;
        [ProtoMember(0x1c)]
        public bool? HasPassword;
        [ProtoMember(0x2e)]
        public SerializableRange ModCount;
        [ProtoMember(0x40)]
        public List<ulong> Mods;
        [ProtoMember(0x3d)]
        public bool ModsExclusive;
        [ProtoMember(0x3a)]
        public int Ping;
        [ProtoMember(40)]
        public SerializableRange PlayerCount;
        [ProtoMember(0x19)]
        public bool SameData;
        [ProtoMember(0x16)]
        public bool SameVersion;
        [ProtoMember(0x22)]
        public bool SurvivalMode;
        [ProtoMember(0x34)]
        public SerializableRange ViewDistance;
    }
}


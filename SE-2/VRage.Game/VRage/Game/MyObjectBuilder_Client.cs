namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_Client : MyObjectBuilder_Base
    {
        [ProtoMember(0x13)]
        public bool IsAdmin;
        [ProtoMember(15), Serialize(MyObjectFlags.DefaultZero)]
        public string Name;
        [ProtoMember(12)]
        public ulong SteamId;
    }
}


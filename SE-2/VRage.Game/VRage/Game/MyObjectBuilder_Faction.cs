namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_Faction
    {
        [ProtoMember(0x37)]
        public bool AcceptHumans = true;
        [ProtoMember(0x31)]
        public bool AutoAcceptMember;
        [ProtoMember(0x34)]
        public bool AutoAcceptPeace;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x23)]
        public string Description;
        [ProtoMember(0x3a)]
        public bool EnableFriendlyFire = true;
        [ProtoMember(0x18)]
        public long FactionId;
        [ProtoMember(0x2e)]
        public List<MyObjectBuilder_FactionMember> JoinRequests;
        [ProtoMember(0x2b)]
        public List<MyObjectBuilder_FactionMember> Members;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x1f)]
        public string Name;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x27)]
        public string PrivateInfo;
        [ProtoMember(0x1b), Serialize(MyObjectFlags.DefaultZero)]
        public string Tag;
    }
}


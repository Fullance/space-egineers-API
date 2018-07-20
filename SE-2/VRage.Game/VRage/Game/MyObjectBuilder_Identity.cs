namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Identity : MyObjectBuilder_Base
    {
        [ProtoMember(0x2a)]
        public int BlockLimitModifier;
        [ProtoMember(0x1f)]
        public long CharacterEntityId;
        [ProtoMember(0x26)]
        public SerializableVector3? ColorMask;
        [ProtoMember(0x1b), Serialize(MyObjectFlags.DefaultZero)]
        public string DisplayName;
        [ProtoMember(0x18)]
        public long IdentityId;
        [ProtoMember(0x2d)]
        public DateTime LastLoginTime;
        [ProtoMember(0x33)]
        public DateTime LastLogoutTime;
        [ProtoMember(0x22), Serialize(MyObjectFlags.DefaultZero)]
        public string Model;
        [ProtoMember(0x36)]
        public List<long> RespawnShips;
        [ProtoMember(0x30, IsRequired=false)]
        public HashSet<long> SavedCharacters;

        public bool ShouldSerializeColorMask() => 
            this.ColorMask.HasValue;

        public bool ShouldSerializePlayerId() => 
            false;

        [NoSerialize]
        public long PlayerId
        {
            get => 
                this.IdentityId;
            set
            {
                this.IdentityId = value;
            }
        }
    }
}


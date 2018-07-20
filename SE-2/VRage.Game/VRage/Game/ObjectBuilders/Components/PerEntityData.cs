namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using VRage.Serialization;

    [ProtoContract]
    public class PerEntityData
    {
        [ProtoMember(0x1c)]
        public SerializableDictionary<int, PerFrameData> Data;
        [ProtoMember(0x19)]
        public long EntityId;
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRage.ObjectBuilders;

    [ProtoContract]
    public class SuitResourceDefinition
    {
        [ProtoMember(0x2f)]
        public SerializableDefinitionId Id;
        [ProtoMember(50)]
        public float MaxCapacity;
        [ProtoMember(0x35)]
        public float Throughput;
    }
}


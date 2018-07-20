namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRage.ObjectBuilders;

    [ProtoContract]
    public class MyFuelConverterInfo
    {
        [ProtoMember(13)]
        public float Efficiency = 1f;
        [ProtoMember(10)]
        public SerializableDefinitionId FuelId = new SerializableDefinitionId();
    }
}


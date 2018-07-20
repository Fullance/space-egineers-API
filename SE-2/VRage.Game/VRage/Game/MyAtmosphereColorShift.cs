namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRageMath;

    [ProtoContract]
    public class MyAtmosphereColorShift
    {
        [ProtoMember(0x200)]
        public SerializableRange B = new SerializableRange();
        [ProtoMember(0x1fd)]
        public SerializableRange G = new SerializableRange();
        [ProtoMember(0x1fa)]
        public SerializableRange R = new SerializableRange();
    }
}


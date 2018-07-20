namespace VRage.Game
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class MyObjectBuilder_MyFeetIKSettings
    {
        [ProtoMember(0x60)]
        public float AboveReachableDistance;
        [ProtoMember(0x6f)]
        public float AnkleHeight;
        [ProtoMember(0x5d)]
        public float BelowReachableDistance;
        [ProtoMember(90)]
        public bool Enabled;
        [ProtoMember(0x69)]
        public float FootLenght;
        [ProtoMember(0x6c)]
        public float FootWidth;
        [ProtoMember(0x57)]
        public string MovementState;
        [ProtoMember(0x66)]
        public float VerticalShiftDownGain;
        [ProtoMember(0x63)]
        public float VerticalShiftUpGain;
    }
}


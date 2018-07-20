namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using VRage;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MovementData
    {
        [ProtoMember(0x23)]
        public SerializableVector3 MoveVector;
        [ProtoMember(0x26)]
        public SerializableVector3 RotateVector;
        [ProtoMember(0x29)]
        public byte MovementFlags;
    }
}


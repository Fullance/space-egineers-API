namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using VRage;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct BoneInfo
    {
        [ProtoMember(0x1c)]
        public SerializableVector3I BonePosition;
        [ProtoMember(0x1f)]
        public SerializableVector3UByte BoneOffset;
    }
}


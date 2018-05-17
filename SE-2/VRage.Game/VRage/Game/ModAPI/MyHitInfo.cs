namespace VRage.Game.ModAPI
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyHitInfo
    {
        [ProtoMember(9)]
        public Vector3D Position;
        [ProtoMember(12)]
        public Vector3 Normal;
        [ProtoMember(15)]
        public Vector3D Velocity;
        [ProtoMember(0x12)]
        public uint ShapeKey;
    }
}


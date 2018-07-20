namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct ShootData
    {
        [ProtoMember(0x3d)]
        public bool Begin;
        [ProtoMember(0x40)]
        public byte ShootAction;
    }
}


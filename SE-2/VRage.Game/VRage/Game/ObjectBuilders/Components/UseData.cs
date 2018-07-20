namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct UseData
    {
        [ProtoMember(100)]
        public bool Use;
        [ProtoMember(0x67)]
        public bool UseContinues;
        [ProtoMember(0x6a)]
        public bool UseFinished;
    }
}


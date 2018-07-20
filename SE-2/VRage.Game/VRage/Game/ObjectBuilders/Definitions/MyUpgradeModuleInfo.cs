namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyUpgradeModuleInfo
    {
        [ProtoMember(0x23)]
        public string UpgradeType { get; set; }
        [ProtoMember(40)]
        public float Modifier { get; set; }
        [ProtoMember(0x2d)]
        public MyUpgradeModifierType ModifierType { get; set; }
    }
}


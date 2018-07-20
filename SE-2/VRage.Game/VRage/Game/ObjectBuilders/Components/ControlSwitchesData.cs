namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct ControlSwitchesData
    {
        [ProtoMember(0x4e)]
        public bool SwitchThrusts;
        [ProtoMember(0x51)]
        public bool SwitchDamping;
        [ProtoMember(0x54)]
        public bool SwitchLights;
        [ProtoMember(0x57)]
        public bool SwitchLandingGears;
        [ProtoMember(90)]
        public bool SwitchReactors;
        [ProtoMember(0x5d)]
        public bool SwitchHelmet;
    }
}


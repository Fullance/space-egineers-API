namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct PerFrameData
    {
        [ProtoMember(0x72)]
        public VRage.Game.ObjectBuilders.Components.MovementData? MovementData;
        [ProtoMember(0x75)]
        public VRage.Game.ObjectBuilders.Components.SwitchWeaponData? SwitchWeaponData;
        [ProtoMember(120)]
        public VRage.Game.ObjectBuilders.Components.ShootData? ShootData;
        [ProtoMember(0x7b)]
        public VRage.Game.ObjectBuilders.Components.AnimationData? AnimationData;
        [ProtoMember(0x7e)]
        public VRage.Game.ObjectBuilders.Components.ControlSwitchesData? ControlSwitchesData;
        [ProtoMember(0x81)]
        public VRage.Game.ObjectBuilders.Components.UseData? UseData;
        public override string ToString()
        {
            if (this.MovementData.HasValue)
            {
                return (this.MovementData.Value.MoveVector.ToString() + "\n" + this.MovementData.Value.RotateVector.ToString() + "\n" + this.MovementData.Value.MovementFlags.ToString());
            }
            return base.ToString();
        }
    }
}


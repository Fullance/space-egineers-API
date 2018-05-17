namespace VRage.Game.ModAPI
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using VRage.Utils;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyDamageInformation
    {
        [ProtoMember(0x15)]
        public bool IsDeformation;
        [ProtoMember(0x18)]
        public float Amount;
        [ProtoMember(0x1b)]
        public MyStringHash Type;
        [ProtoMember(30)]
        public long AttackerId;
        public MyDamageInformation(bool isDeformation, float amount, MyStringHash type, long attackerId)
        {
            this.IsDeformation = isDeformation;
            this.Amount = amount;
            this.Type = type;
            this.AttackerId = attackerId;
        }
    }
}


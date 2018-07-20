namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct SwitchWeaponData
    {
        [ProtoMember(0x30)]
        public MyDefinitionId? WeaponDefinition;
        [ProtoMember(0x33)]
        public uint? InventoryItemId;
        [ProtoMember(0x36)]
        public long WeaponEntityId;
    }
}


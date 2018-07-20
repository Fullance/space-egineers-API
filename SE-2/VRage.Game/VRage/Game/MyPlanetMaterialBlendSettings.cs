namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyPlanetMaterialBlendSettings
    {
        [ProtoMember(0x207)]
        public string Texture;
        [ProtoMember(0x20a)]
        public int CellSize;
    }
}


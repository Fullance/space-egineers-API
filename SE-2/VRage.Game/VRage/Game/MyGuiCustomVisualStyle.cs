namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyGuiCustomVisualStyle
    {
        [ProtoMember(0x19)]
        public string NormalTexture;
        [ProtoMember(0x1b)]
        public string HighlightTexture;
        [ProtoMember(0x1d)]
        public Vector2 Size;
        [ProtoMember(0x1f)]
        public string NormalFont;
        [ProtoMember(0x21)]
        public string HighlightFont;
        [ProtoMember(0x23)]
        public float HorizontalPadding;
        [ProtoMember(0x25)]
        public float VerticalPadding;
    }
}


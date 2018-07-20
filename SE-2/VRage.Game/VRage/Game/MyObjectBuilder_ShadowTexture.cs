namespace VRage.Game
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class MyObjectBuilder_ShadowTexture
    {
        [ProtoMember(0x21)]
        public float DefaultAlpha = 1f;
        [ProtoMember(30)]
        public float GrowFactorHeight = 1f;
        [ProtoMember(0x1b)]
        public float GrowFactorWidth = 1f;
        [ProtoMember(0x18)]
        public float MinWidth;
        [ProtoMember(0x15)]
        public string Texture = "";
    }
}


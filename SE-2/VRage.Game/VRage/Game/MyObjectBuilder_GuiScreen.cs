namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GuiScreen : MyObjectBuilder_Base
    {
        [ProtoMember(0x13)]
        public Vector4? BackgroundColor;
        [ProtoMember(0x16)]
        public string BackgroundTexture;
        [ProtoMember(0x1c)]
        public bool CloseButtonEnabled;
        [ProtoMember(0x1f)]
        public Vector2 CloseButtonOffset;
        [ProtoMember(0x10)]
        public MyObjectBuilder_GuiControls Controls;
        [ProtoMember(0x19)]
        public Vector2? Size;

        public bool ShouldSerializeCloseButtonOffset() => 
            this.CloseButtonEnabled;
    }
}


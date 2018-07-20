namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_GuiControlButton : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(0x38)]
        public bool DrawCrossTextureWhenDisabled;
        [ProtoMember(0x3b)]
        public bool DrawRedTextureWhenDisabled;
        [ProtoMember(0x2c)]
        public string Text;
        [ProtoMember(0x35)]
        public int TextAlignment;
        [ProtoMember(0x2f)]
        public string TextEnum;
        [ProtoMember(50)]
        public float TextScale;
        [ProtoMember(0x3e)]
        public MyGuiControlButtonStyleEnum VisualStyle;
    }
}


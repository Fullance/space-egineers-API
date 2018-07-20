namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_GuiControlMultilineLabel : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(0x1b)]
        public string Font;
        [ProtoMember(0x15)]
        public string Text;
        [ProtoMember(15)]
        public int TextAlign;
        [ProtoMember(0x18)]
        public int TextBoxAlign;
        [ProtoMember(0x12)]
        public Vector4 TextColor = Vector4.One;
        [ProtoMember(12)]
        public float TextScale = 1f;
    }
}


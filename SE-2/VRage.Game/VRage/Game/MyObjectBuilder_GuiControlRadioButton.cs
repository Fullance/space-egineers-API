namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_GuiControlRadioButton : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(0x37)]
        public MyGuiCustomVisualStyle? CustomVisualStyle = null;
        [ProtoMember(0x2e)]
        public int Key;
        [ProtoMember(0x31)]
        public MyGuiControlRadioButtonStyleEnum VisualStyle;
    }
}


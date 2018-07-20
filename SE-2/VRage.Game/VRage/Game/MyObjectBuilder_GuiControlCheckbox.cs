namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_GuiControlCheckbox : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(0x19)]
        public string CheckedTexture;
        [ProtoMember(0x16)]
        public bool IsChecked;
        [ProtoMember(0x1c)]
        public MyGuiControlCheckboxStyleEnum VisualStyle;
    }
}


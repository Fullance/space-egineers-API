namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_GuiControlGrid : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(0x19)]
        public int DisplayColumnsCount = 1;
        [ProtoMember(0x1c)]
        public int DisplayRowsCount = 1;
        [ProtoMember(0x16)]
        public MyGuiControlGridStyleEnum VisualStyle;
    }
}


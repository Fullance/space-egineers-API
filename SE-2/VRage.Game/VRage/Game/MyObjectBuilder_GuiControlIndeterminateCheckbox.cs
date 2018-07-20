namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_GuiControlIndeterminateCheckbox : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(0x19)]
        public CheckStateEnum State;
        [ProtoMember(0x1c)]
        public MyGuiControlIndeterminateCheckboxStyleEnum VisualStyle;
    }
}


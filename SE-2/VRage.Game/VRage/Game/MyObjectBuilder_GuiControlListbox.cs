namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_GuiControlListbox : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(0x19)]
        public int VisibleRows;
        [ProtoMember(0x16)]
        public MyGuiControlListboxStyleEnum VisualStyle;
    }
}


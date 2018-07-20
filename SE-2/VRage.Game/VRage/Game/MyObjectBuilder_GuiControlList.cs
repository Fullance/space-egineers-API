namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_GuiControlList : MyObjectBuilder_GuiControlParent
    {
        [ProtoMember(0x13)]
        public MyGuiControlListStyleEnum VisualStyle;
    }
}


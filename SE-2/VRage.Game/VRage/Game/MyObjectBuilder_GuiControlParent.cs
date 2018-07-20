namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GuiControlParent : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(11)]
        public MyObjectBuilder_GuiControls Controls;
    }
}


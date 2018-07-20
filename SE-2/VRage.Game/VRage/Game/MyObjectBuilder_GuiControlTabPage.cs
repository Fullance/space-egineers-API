namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GuiControlTabPage : MyObjectBuilder_GuiControlParent
    {
        [ProtoMember(11)]
        public int PageKey;
        [ProtoMember(14)]
        public string TextEnum;
        [ProtoMember(0x11)]
        public float TextScale;
    }
}


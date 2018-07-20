namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GuiControlSeparatorList : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(30)]
        public List<Separator> Separators = new List<Separator>();

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct Separator
        {
            [XmlAttribute, DefaultValue((float) 0f), ProtoMember(0x11)]
            public float StartX { get; set; }
            [DefaultValue((float) 0f), XmlAttribute, ProtoMember(20)]
            public float StartY { get; set; }
            [XmlAttribute, DefaultValue((float) 0f), ProtoMember(0x17)]
            public float SizeX { get; set; }
            [DefaultValue((float) 0f), ProtoMember(0x1a), XmlAttribute]
            public float SizeY { get; set; }
        }
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_TerminalBlock : MyObjectBuilder_CubeBlock
    {
        [ProtoMember(13), Serialize(MyObjectFlags.DefaultZero), DefaultValue((string) null)]
        public string CustomName;
        [ProtoMember(0x1a)]
        public bool ShowInInventory = true;
        [ProtoMember(20)]
        public bool ShowInTerminal = true;
        [ProtoMember(0x17)]
        public bool ShowInToolbarConfig = true;
        [ProtoMember(0x11)]
        public bool ShowOnHUD;
    }
}


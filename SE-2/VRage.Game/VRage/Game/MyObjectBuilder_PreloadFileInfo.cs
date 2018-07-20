namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_PreloadFileInfo : MyObjectBuilder_Base
    {
        [DefaultValue(false), ProtoMember(0x1a)]
        public bool LoadOnDedicated;
        [ProtoMember(0x17)]
        public string Name;
    }
}


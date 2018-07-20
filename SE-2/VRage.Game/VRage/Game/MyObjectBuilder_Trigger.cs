namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Trigger : MyObjectBuilder_Base
    {
        [ProtoMember(11)]
        public bool IsTrue;
        [ProtoMember(13)]
        public string Message;
        [ProtoMember(0x11)]
        public string NextMission;
        [ProtoMember(15)]
        public string WwwLink;
    }
}


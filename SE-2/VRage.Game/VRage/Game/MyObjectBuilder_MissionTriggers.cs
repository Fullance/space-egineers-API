namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_MissionTriggers : MyObjectBuilder_Base
    {
        [ProtoMember(14)]
        public List<MyObjectBuilder_Trigger> LoseTriggers = new List<MyObjectBuilder_Trigger>();
        [ProtoMember(20)]
        public bool Lost;
        [ProtoMember(0x10)]
        public string message;
        [ProtoMember(12)]
        public List<MyObjectBuilder_Trigger> WinTriggers = new List<MyObjectBuilder_Trigger>();
        [ProtoMember(0x12)]
        public bool Won;
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_JetpackDefinition
    {
        [ProtoMember(40)]
        public MyObjectBuilder_ThrustDefinition ThrustProperties;
        [ProtoMember(0x24), XmlArrayItem("Thrust")]
        public List<MyJetpackThrustDefinition> Thrusts;
    }
}


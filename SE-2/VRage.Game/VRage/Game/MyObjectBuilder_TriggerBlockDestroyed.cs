namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_TriggerBlockDestroyed : MyObjectBuilder_Trigger
    {
        [ProtoMember(12)]
        public List<long> BlockIds;
        [ProtoMember(14)]
        public string SingleMessage;
    }
}


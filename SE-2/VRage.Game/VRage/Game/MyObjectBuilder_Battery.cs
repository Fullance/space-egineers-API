namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Battery : MyObjectBuilder_Base
    {
        [ProtoMember(15)]
        public float CurrentCapacity;
        [ProtoMember(12), DefaultValue(true)]
        public bool ProducerEnabled = true;
    }
}


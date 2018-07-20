namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GlobalEventBase : MyObjectBuilder_Base
    {
        [ProtoMember(0x16)]
        public long ActivationTimeMs;
        [ProtoMember(12)]
        public SerializableDefinitionId? DefinitionId = null;
        [ProtoMember(0x13)]
        public bool Enabled;
        [ProtoMember(0x19)]
        public MyGlobalEventTypeEnum EventType;

        public bool ShouldSerializeDefinitionId() => 
            false;

        public bool ShouldSerializeEventType() => 
            false;
    }
}


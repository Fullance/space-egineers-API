namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, "EventDefinition")]
    public class MyObjectBuilder_GlobalEventDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x2e)]
        public long? FirstActivationTimeMs;
        [ProtoMember(0x2a)]
        public long? MaxActivationTimeMs;
        [ProtoMember(0x26)]
        public long? MinActivationTimeMs;

        public bool ShouldSerializeFirstActivationTime() => 
            this.FirstActivationTimeMs.HasValue;

        public bool ShouldSerializeMaxActivationTime() => 
            this.MaxActivationTimeMs.HasValue;

        public bool ShouldSerializeMinActivationTime() => 
            this.MinActivationTimeMs.HasValue;

        [ProtoMember(0x1f)]
        private MyGlobalEventTypeEnum EventType
        {
            get => 
                MyGlobalEventTypeEnum.InvalidEventType;
            set
            {
            }
        }
    }
}


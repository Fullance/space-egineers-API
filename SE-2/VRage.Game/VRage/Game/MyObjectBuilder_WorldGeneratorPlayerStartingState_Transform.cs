namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlType("Transform"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_WorldGeneratorPlayerStartingState_Transform : MyObjectBuilder_WorldGeneratorPlayerStartingState
    {
        [XmlAttribute, ProtoMember(0xb2)]
        public bool DampenersEnabled;
        [XmlAttribute, ProtoMember(0xaf)]
        public bool JetpackEnabled;
        [ProtoMember(0xab)]
        public MyPositionAndOrientation? Transform;

        public bool ShouldSerializeTransform() => 
            this.Transform.HasValue;
    }
}


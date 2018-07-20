namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageRender.Animations;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_AnimationSMTransition : MyObjectBuilder_Base
    {
        [ProtoMember(0x25), XmlArrayItem("Conjunction")]
        public MyObjectBuilder_AnimationSMConditionsConjunction[] Conditions;
        [XmlAttribute, ProtoMember(0x2e)]
        public MyAnimationTransitionCurve Curve;
        [XmlAttribute, ProtoMember(0x13)]
        public string From;
        [ProtoMember(14), XmlAttribute]
        public string Name;
        [ProtoMember(0x2b)]
        public int? Priority;
        [ProtoMember(0x20), XmlAttribute]
        public MyAnimationTransitionSyncType Sync;
        [XmlAttribute, ProtoMember(0x1c)]
        public double TimeInSec;
        [XmlAttribute, ProtoMember(0x18)]
        public string To;
    }
}


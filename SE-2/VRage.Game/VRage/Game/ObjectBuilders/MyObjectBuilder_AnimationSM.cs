namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AnimationSM : MyObjectBuilder_Base
    {
        [ProtoMember(14)]
        public string Name;
        [ProtoMember(0x12), XmlArrayItem("Node")]
        public MyObjectBuilder_AnimationSMNode[] Nodes;
        [XmlArrayItem("Transition"), ProtoMember(0x17)]
        public MyObjectBuilder_AnimationSMTransition[] Transitions;
    }
}


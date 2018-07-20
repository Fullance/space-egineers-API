namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlType("AnimationControllerDefinition"), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_AnimationControllerDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x17), XmlArrayItem("FootIkChain")]
        public MyObjectBuilder_AnimationFootIkChain[] FootIkChains;
        [ProtoMember(0x1b), XmlArrayItem("Bone")]
        public string[] IkIgnoredBones;
        [XmlArrayItem("Layer"), ProtoMember(15)]
        public MyObjectBuilder_AnimationLayer[] Layers;
        [ProtoMember(0x13), XmlArrayItem("StateMachine")]
        public MyObjectBuilder_AnimationSM[] StateMachines;

        public MyObjectBuilder_AnimationControllerDefinition()
        {
            this.Id.TypeId = typeof(MyObjectBuilder_AnimationControllerDefinition);
        }
    }
}


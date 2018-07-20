namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlType("AnimationIkChain"), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AnimationFootIkChain : MyObjectBuilder_Base
    {
        [ProtoMember(0x11)]
        public bool AlignBoneWithTerrain = true;
        [ProtoMember(15)]
        public int ChainLength = 1;
        [ProtoMember(13)]
        public string FootBone;
    }
}


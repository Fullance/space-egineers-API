namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AnimationTreeNodeDynamicTrack : MyObjectBuilder_AnimationTreeNodeTrack
    {
        [ProtoMember(0x71)]
        public string DefaultAnimation;
    }
}


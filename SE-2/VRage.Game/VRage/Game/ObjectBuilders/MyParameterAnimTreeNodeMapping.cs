namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyParameterAnimTreeNodeMapping
    {
        [ProtoMember(0xc7)]
        public float Param;
        [ProtoMember(0xc9), XmlElement(typeof(MyAbstractXmlSerializer<MyObjectBuilder_AnimationTreeNode>))]
        public MyObjectBuilder_AnimationTreeNode Node;
    }
}


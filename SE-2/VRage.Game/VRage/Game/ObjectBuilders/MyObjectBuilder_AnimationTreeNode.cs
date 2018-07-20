namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public abstract class MyObjectBuilder_AnimationTreeNode : MyObjectBuilder_Base
    {
        [ProtoMember(20)]
        public Vector2I? EdPos;

        protected MyObjectBuilder_AnimationTreeNode()
        {
        }

        protected internal abstract MyObjectBuilder_AnimationTreeNode DeepCopyWithMask(HashSet<MyObjectBuilder_AnimationTreeNode> selectedNodes, MyObjectBuilder_AnimationTreeNode parentNode, List<MyObjectBuilder_AnimationTreeNode> orphans);
        public abstract MyObjectBuilder_AnimationTreeNode[] GetChildren();
    }
}


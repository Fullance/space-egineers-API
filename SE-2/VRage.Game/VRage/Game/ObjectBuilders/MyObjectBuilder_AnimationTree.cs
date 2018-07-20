namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AnimationTree : MyObjectBuilder_AnimationTreeNode
    {
        [XmlElement(typeof(MyAbstractXmlSerializer<MyObjectBuilder_AnimationTreeNode>)), ProtoMember(0x30)]
        public MyObjectBuilder_AnimationTreeNode Child;
        [ProtoMember(0x36), XmlArrayItem(typeof(MyAbstractXmlSerializer<MyObjectBuilder_AnimationTreeNode>))]
        public MyObjectBuilder_AnimationTreeNode[] Orphans;

        public MyObjectBuilder_AnimationTree DeepCopyWithMask(HashSet<MyObjectBuilder_AnimationTreeNode> selectedNodes)
        {
            List<MyObjectBuilder_AnimationTreeNode> orphans = new List<MyObjectBuilder_AnimationTreeNode>();
            if (this.Orphans != null)
            {
                foreach (MyObjectBuilder_AnimationTreeNode node in this.Orphans)
                {
                    node.DeepCopyWithMask(selectedNodes, null, orphans);
                }
            }
            return (MyObjectBuilder_AnimationTree) this.DeepCopyWithMask(selectedNodes, null, orphans);
        }

        protected internal override MyObjectBuilder_AnimationTreeNode DeepCopyWithMask(HashSet<MyObjectBuilder_AnimationTreeNode> selectedNodes, MyObjectBuilder_AnimationTreeNode parentNode, List<MyObjectBuilder_AnimationTreeNode> orphans)
        {
            MyObjectBuilder_AnimationTree tree = new MyObjectBuilder_AnimationTree();
            if (this.Child == null)
            {
                tree.Child = null;
                tree.Orphans = (orphans.Count > 0) ? orphans.ToArray() : null;
                return tree;
            }
            MyObjectBuilder_AnimationTreeNode node = this.Child.DeepCopyWithMask(selectedNodes, tree, orphans);
            tree.EdPos = base.EdPos;
            tree.Child = node;
            tree.Orphans = (orphans.Count > 0) ? orphans.ToArray() : null;
            return tree;
        }

        public override MyObjectBuilder_AnimationTreeNode[] GetChildren()
        {
            if (this.Child != null)
            {
                return new MyObjectBuilder_AnimationTreeNode[] { this.Child };
            }
            return null;
        }
    }
}


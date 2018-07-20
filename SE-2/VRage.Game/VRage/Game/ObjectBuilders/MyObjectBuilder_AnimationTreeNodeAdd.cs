namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AnimationTreeNodeAdd : MyObjectBuilder_AnimationTreeNode
    {
        [ProtoMember(0x13f)]
        public MyParameterAnimTreeNodeMapping AddNode;
        [ProtoMember(0x139)]
        public MyParameterAnimTreeNodeMapping BaseNode;
        [ProtoMember(0x133)]
        public string ParameterName;

        protected internal override MyObjectBuilder_AnimationTreeNode DeepCopyWithMask(HashSet<MyObjectBuilder_AnimationTreeNode> selectedNodes, MyObjectBuilder_AnimationTreeNode parentNode, List<MyObjectBuilder_AnimationTreeNode> orphans)
        {
            bool flag = (selectedNodes == null) || selectedNodes.Contains(this);
            MyObjectBuilder_AnimationTreeNodeAdd item = new MyObjectBuilder_AnimationTreeNodeAdd {
                EdPos = base.EdPos,
                ParameterName = this.ParameterName,
                BaseNode = { 
                    Param = this.BaseNode.Param,
                    Node = 0
                },
                AddNode = { 
                    Param = this.AddNode.Param,
                    Node = 0
                }
            };
            item.BaseNode.Node = this.BaseNode.Node.DeepCopyWithMask(selectedNodes, flag ? item : null, orphans);
            item.AddNode.Node = this.AddNode.Node.DeepCopyWithMask(selectedNodes, flag ? item : null, orphans);
            if (!flag)
            {
                return null;
            }
            if (parentNode == null)
            {
                orphans.Add(item);
            }
            return item;
        }

        public override MyObjectBuilder_AnimationTreeNode[] GetChildren()
        {
            List<MyObjectBuilder_AnimationTreeNode> list = new List<MyObjectBuilder_AnimationTreeNode>();
            if (this.BaseNode.Node != null)
            {
                list.Add(this.BaseNode.Node);
            }
            if (this.AddNode.Node != null)
            {
                list.Add(this.AddNode.Node);
            }
            if (list.Count > 0)
            {
                return list.ToArray();
            }
            return null;
        }
    }
}


namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_AnimationTreeNodeIkTarget : MyObjectBuilder_AnimationTreeNode
    {
        [ProtoMember(0x174), XmlArrayItem("Bone")]
        public string[] BoneChain;
        [ProtoMember(380)]
        public string TargetBoneName;
        [ProtoMember(0x183)]
        public string TargetPoint;

        protected internal override MyObjectBuilder_AnimationTreeNode DeepCopyWithMask(HashSet<MyObjectBuilder_AnimationTreeNode> selectedNodes, MyObjectBuilder_AnimationTreeNode parentNode, List<MyObjectBuilder_AnimationTreeNode> orphans)
        {
            bool flag = (selectedNodes == null) || selectedNodes.Contains(this);
            MyObjectBuilder_AnimationTreeNodeIkTarget item = new MyObjectBuilder_AnimationTreeNodeIkTarget {
                EdPos = base.EdPos,
                TargetBoneName = this.TargetBoneName,
                TargetPoint = this.TargetPoint,
                BoneChain = null
            };
            if (this.BoneChain != null)
            {
                item.BoneChain = new string[this.BoneChain.Length];
                for (int i = 0; i < this.BoneChain.Length; i++)
                {
                    item.BoneChain[i] = this.BoneChain[i];
                }
            }
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

        public override MyObjectBuilder_AnimationTreeNode[] GetChildren() => 
            null;
    }
}


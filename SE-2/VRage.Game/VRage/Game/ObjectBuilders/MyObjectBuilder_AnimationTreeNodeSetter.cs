namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_AnimationTreeNodeSetter : MyObjectBuilder_AnimationTreeNode
    {
        [ProtoMember(0x1bf), XmlElement(typeof(MyAbstractXmlSerializer<MyObjectBuilder_AnimationTreeNode>))]
        public MyObjectBuilder_AnimationTreeNode Child;
        [ProtoMember(0x1d4)]
        public float ResetValue;
        [ProtoMember(0x1cf)]
        public bool ResetValueEnabled;
        [ProtoMember(0x1c5)]
        public float Time;
        [ProtoMember(0x1ca)]
        public ValueAssignment Value;

        protected internal override MyObjectBuilder_AnimationTreeNode DeepCopyWithMask(HashSet<MyObjectBuilder_AnimationTreeNode> selectedNodes, MyObjectBuilder_AnimationTreeNode parentNode, List<MyObjectBuilder_AnimationTreeNode> orphans)
        {
            bool flag = (selectedNodes == null) || selectedNodes.Contains(this);
            MyObjectBuilder_AnimationTreeNodeSetter item = new MyObjectBuilder_AnimationTreeNodeSetter {
                Value = this.Value,
                ResetValue = this.ResetValue,
                Time = this.Time,
                EdPos = base.EdPos,
                ResetValueEnabled = this.ResetValueEnabled
            };
            if (this.Child != null)
            {
                item.Child = this.Child.DeepCopyWithMask(selectedNodes, flag ? item : null, orphans);
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

        public override MyObjectBuilder_AnimationTreeNode[] GetChildren()
        {
            if (this.Child != null)
            {
                return new MyObjectBuilder_AnimationTreeNode[] { this.Child };
            }
            return null;
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct ValueAssignment
        {
            [ProtoMember(0x1b4)]
            public string Name;
            [ProtoMember(0x1b9)]
            public float Value;
        }
    }
}


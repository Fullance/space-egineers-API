namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_AnimationTreeNodeTrack : MyObjectBuilder_AnimationTreeNode
    {
        [ProtoMember(0x87)]
        public string AnimationName;
        [ProtoMember(0x99)]
        public bool Interpolate = true;
        [ProtoMember(0x8d)]
        public bool Loop = true;
        [ProtoMember(0x81)]
        public string PathToModel;
        [ProtoMember(0x93)]
        public double Speed = 1.0;
        [ProtoMember(0x9f)]
        public string SynchronizeWithLayer;

        protected internal override MyObjectBuilder_AnimationTreeNode DeepCopyWithMask(HashSet<MyObjectBuilder_AnimationTreeNode> selectedNodes, MyObjectBuilder_AnimationTreeNode parentNode, List<MyObjectBuilder_AnimationTreeNode> orphans)
        {
            bool flag = (selectedNodes == null) || selectedNodes.Contains(this);
            MyObjectBuilder_AnimationTreeNodeTrack item = new MyObjectBuilder_AnimationTreeNodeTrack {
                PathToModel = this.PathToModel,
                AnimationName = this.AnimationName,
                Loop = this.Loop,
                Speed = this.Speed,
                Interpolate = this.Interpolate,
                SynchronizeWithLayer = this.SynchronizeWithLayer,
                EdPos = base.EdPos
            };
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


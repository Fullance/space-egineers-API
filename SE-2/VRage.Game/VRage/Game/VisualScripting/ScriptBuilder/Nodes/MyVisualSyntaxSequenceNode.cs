namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using System;
    using VRage.Game;
    using VRage.Game.ObjectBuilders.VisualScripting;

    public class MyVisualSyntaxSequenceNode : MyVisualSyntaxNode
    {
        public MyVisualSyntaxSequenceNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                if (this.ObjectBuilder.SequenceInput != -1)
                {
                    MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceInput);
                    this.SequenceInputs.Add(nodeByID);
                }
                foreach (int num in this.ObjectBuilder.SequenceOutputs)
                {
                    if (num != -1)
                    {
                        MyVisualSyntaxNode item = base.Navigator.GetNodeByID(num);
                        this.SequenceOutputs.Add(item);
                    }
                }
            }
            base.Preprocess(currentDepth);
        }

        public MyObjectBuilder_SequenceScriptNode ObjectBuilder =>
            ((MyObjectBuilder_SequenceScriptNode) base.m_objectBuilder);
    }
}


namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game;

    public class MyVisualSyntaxGetterNode : MyVisualSyntaxNode
    {
        public MyVisualSyntaxGetterNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                for (int i = 0; i < this.ObjectBuilder.OutputIDs.Ids.Count; i++)
                {
                    MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.OutputIDs.Ids[i].NodeID);
                    if (nodeByID != null)
                    {
                        this.Outputs.Add(nodeByID);
                    }
                }
            }
            base.Preprocess(currentDepth);
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null) => 
            this.ObjectBuilder.BoundVariableName;

        public MyObjectBuilder_GetterScriptNode ObjectBuilder =>
            ((MyObjectBuilder_GetterScriptNode) base.m_objectBuilder);

        internal override bool SequenceDependent =>
            false;
    }
}


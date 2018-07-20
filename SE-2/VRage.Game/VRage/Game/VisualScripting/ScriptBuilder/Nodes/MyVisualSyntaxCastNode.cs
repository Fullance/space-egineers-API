namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxCastNode : MyVisualSyntaxNode
    {
        private MyVisualSyntaxNode m_inputNode;
        private MyVisualSyntaxNode m_nextSequenceNode;

        public MyVisualSyntaxCastNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        internal override void CollectInputExpressions(List<StatementSyntax> expressions)
        {
            base.CollectInputExpressions(expressions);
            expressions.Add(MySyntaxFactory.CastExpression(this.m_inputNode.VariableSyntaxName(this.ObjectBuilder.InputID.VariableName), this.ObjectBuilder.Type, this.VariableSyntaxName(null)));
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                if (this.ObjectBuilder.SequenceOuputID != -1)
                {
                    this.m_nextSequenceNode = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceOuputID);
                    this.SequenceOutputs.Add(this.m_nextSequenceNode);
                }
                MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceInputID);
                this.SequenceInputs.Add(nodeByID);
                if (this.ObjectBuilder.InputID.NodeID == -1)
                {
                    throw new Exception("Cast node has no input. NodeId: " + this.ObjectBuilder.ID);
                }
                this.m_inputNode = base.Navigator.GetNodeByID(this.ObjectBuilder.InputID.NodeID);
                this.Inputs.Add(this.m_inputNode);
            }
            base.Preprocess(currentDepth);
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null) => 
            ("castResult_" + this.ObjectBuilder.ID);

        public MyObjectBuilder_CastScriptNode ObjectBuilder =>
            ((MyObjectBuilder_CastScriptNode) base.m_objectBuilder);
    }
}


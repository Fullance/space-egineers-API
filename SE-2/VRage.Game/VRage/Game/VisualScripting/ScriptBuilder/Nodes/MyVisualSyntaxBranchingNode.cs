namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using System;
    using System.Collections.Generic;
    using VRage.Game;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxBranchingNode : MyVisualSyntaxNode
    {
        private MyVisualSyntaxNode m_comparerNode;
        private MyVisualSyntaxNode m_nextFalseSequenceNode;
        private MyVisualSyntaxNode m_nextTrueSequenceNode;

        public MyVisualSyntaxBranchingNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        internal override void CollectSequenceExpressions(List<StatementSyntax> expressions)
        {
            this.CollectInputExpressions(expressions);
            List<StatementSyntax> list = new List<StatementSyntax>();
            List<StatementSyntax> list2 = new List<StatementSyntax>();
            if (this.m_nextTrueSequenceNode != null)
            {
                this.m_nextTrueSequenceNode.CollectSequenceExpressions(list);
            }
            if (this.m_nextFalseSequenceNode != null)
            {
                this.m_nextFalseSequenceNode.CollectSequenceExpressions(list2);
            }
            string conditionVariableName = this.m_comparerNode.VariableSyntaxName(this.ObjectBuilder.InputID.VariableName);
            expressions.Add(MySyntaxFactory.IfExpressionSyntax(conditionVariableName, list, list2));
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                if (this.ObjectBuilder.SequenceTrueOutputID != -1)
                {
                    this.m_nextTrueSequenceNode = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceTrueOutputID);
                    this.SequenceOutputs.Add(this.m_nextTrueSequenceNode);
                }
                if (this.ObjectBuilder.SequnceFalseOutputID != -1)
                {
                    this.m_nextFalseSequenceNode = base.Navigator.GetNodeByID(this.ObjectBuilder.SequnceFalseOutputID);
                    this.SequenceOutputs.Add(this.m_nextFalseSequenceNode);
                }
                if (this.ObjectBuilder.SequenceInputID != -1)
                {
                    MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceInputID);
                    this.SequenceInputs.Add(nodeByID);
                }
                if (this.ObjectBuilder.InputID.NodeID == -1)
                {
                    throw new Exception("Branching node has no comparer input. NodeID: " + this.ObjectBuilder.ID);
                }
                this.m_comparerNode = base.Navigator.GetNodeByID(this.ObjectBuilder.InputID.NodeID);
                this.Inputs.Add(this.m_comparerNode);
            }
            base.Preprocess(currentDepth);
        }

        public MyObjectBuilder_BranchingScriptNode ObjectBuilder =>
            ((MyObjectBuilder_BranchingScriptNode) base.m_objectBuilder);
    }
}


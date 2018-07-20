namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxArithmeticNode : MyVisualSyntaxNode
    {
        private MyVisualSyntaxNode m_inputANode;
        private MyVisualSyntaxNode m_inputBNode;

        public MyVisualSyntaxArithmeticNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        internal override void CollectInputExpressions(List<StatementSyntax> expressions)
        {
            base.CollectInputExpressions(expressions);
            string leftSide = null;
            string rightSide = null;
            leftSide = this.m_inputANode.VariableSyntaxName(this.ObjectBuilder.InputAID.VariableName);
            rightSide = (this.m_inputBNode != null) ? this.m_inputBNode.VariableSyntaxName(this.ObjectBuilder.InputBID.VariableName) : "null";
            if (((this.m_inputBNode == null) && (this.ObjectBuilder.Operation != "==")) && (this.ObjectBuilder.Operation != "!="))
            {
                throw new Exception("Null check with Operation " + this.ObjectBuilder.Operation + " is prohibited.");
            }
            expressions.Add(MySyntaxFactory.ArithmeticStatement(this.VariableSyntaxName(null), leftSide, rightSide, this.ObjectBuilder.Operation));
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                if (this.ObjectBuilder.InputAID.NodeID == -1)
                {
                    throw new Exception("Missing inputA in arithmetic node: " + this.ObjectBuilder.ID);
                }
                this.m_inputANode = base.Navigator.GetNodeByID(this.ObjectBuilder.InputAID.NodeID);
                if (this.ObjectBuilder.InputBID.NodeID != -1)
                {
                    this.m_inputBNode = base.Navigator.GetNodeByID(this.ObjectBuilder.InputBID.NodeID);
                    if (this.m_inputBNode == null)
                    {
                        throw new Exception("Missing inputB in arithmetic node: " + this.ObjectBuilder.ID);
                    }
                }
                for (int i = 0; i < this.ObjectBuilder.OutputNodeIDs.Count; i++)
                {
                    if (this.ObjectBuilder.OutputNodeIDs[i].NodeID == -1)
                    {
                        throw new Exception("-1 output in arithmetic node: " + this.ObjectBuilder.ID);
                    }
                    MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.OutputNodeIDs[i].NodeID);
                    this.Outputs.Add(nodeByID);
                }
                this.Inputs.Add(this.m_inputANode);
                if (this.m_inputBNode != null)
                {
                    this.Inputs.Add(this.m_inputBNode);
                }
            }
            base.Preprocess(currentDepth);
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null) => 
            ("arithmeticResult_" + base.m_objectBuilder.ID);

        public MyObjectBuilder_ArithmeticScriptNode ObjectBuilder =>
            ((MyObjectBuilder_ArithmeticScriptNode) base.m_objectBuilder);

        internal override bool SequenceDependent =>
            false;
    }
}


namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Collections.Generic;
    using VRage.Game;
    using VRage.Game.VisualScripting;
    using VRage.Game.VisualScripting.Utils;
    using VRageMath;

    public class MyVisualSyntaxSetterNode : MyVisualSyntaxNode
    {
        private MyVisualSyntaxNode m_inputNode;
        private string m_inputVariableName;

        public MyVisualSyntaxSetterNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        internal override void CollectInputExpressions(List<StatementSyntax> expressions)
        {
            base.CollectInputExpressions(expressions);
            if (this.ObjectBuilder.ValueInputID.NodeID != -1)
            {
                this.m_inputVariableName = this.m_inputNode.VariableSyntaxName(this.ObjectBuilder.ValueInputID.VariableName);
            }
            expressions.Add(this.GetCorrectAssignmentsExpression());
        }

        private StatementSyntax GetCorrectAssignmentsExpression()
        {
            Type type = MyVisualScriptingProxy.GetType(base.Navigator.GetVariable(this.ObjectBuilder.VariableName).ObjectBuilder.VariableType);
            if (type == typeof(string))
            {
                if (this.ObjectBuilder.ValueInputID.NodeID == -1)
                {
                    return MySyntaxFactory.VariableAssignmentExpression(this.ObjectBuilder.VariableName, this.ObjectBuilder.VariableValue, SyntaxKind.StringLiteralExpression);
                }
            }
            else if (type == typeof(Vector3D))
            {
                if (this.ObjectBuilder.ValueInputID.NodeID == -1)
                {
                    return MySyntaxFactory.SimpleAssignment(this.ObjectBuilder.VariableName, MySyntaxFactory.NewVector3D(this.ObjectBuilder.VariableValue));
                }
            }
            else if (type == typeof(bool))
            {
                if (this.ObjectBuilder.ValueInputID.NodeID == -1)
                {
                    SyntaxKind expressionKind = (MySyntaxFactory.NormalizeBool(this.ObjectBuilder.VariableValue) == "true") ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression;
                    return MySyntaxFactory.VariableAssignmentExpression(this.ObjectBuilder.VariableName, this.ObjectBuilder.VariableValue, expressionKind);
                }
            }
            else if (this.ObjectBuilder.ValueInputID.NodeID == -1)
            {
                return MySyntaxFactory.VariableAssignmentExpression(this.ObjectBuilder.VariableName, this.ObjectBuilder.VariableValue, SyntaxKind.NumericLiteralExpression);
            }
            return MySyntaxFactory.SimpleAssignment(this.ObjectBuilder.VariableName, SyntaxFactory.IdentifierName(this.m_inputVariableName));
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                if (this.ObjectBuilder.SequenceOutputID != -1)
                {
                    MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceOutputID);
                    this.SequenceOutputs.Add(nodeByID);
                }
                if (this.ObjectBuilder.SequenceInputID != -1)
                {
                    MyVisualSyntaxNode item = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceInputID);
                    this.SequenceInputs.Add(item);
                }
                if (this.ObjectBuilder.ValueInputID.NodeID != -1)
                {
                    this.m_inputNode = base.Navigator.GetNodeByID(this.ObjectBuilder.ValueInputID.NodeID);
                    this.Inputs.Add(this.m_inputNode);
                }
            }
            base.Preprocess(currentDepth);
        }

        public MyObjectBuilder_VariableSetterScriptNode ObjectBuilder =>
            ((MyObjectBuilder_VariableSetterScriptNode) base.m_objectBuilder);

        internal override bool SequenceDependent =>
            true;
    }
}


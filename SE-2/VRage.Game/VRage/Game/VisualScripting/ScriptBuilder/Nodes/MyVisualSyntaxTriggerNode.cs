namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using VRage.Game;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxTriggerNode : MyVisualSyntaxNode
    {
        public MyVisualSyntaxTriggerNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        internal override void CollectInputExpressions(List<StatementSyntax> expressions)
        {
            List<string> orderedVariableNames = new List<string>();
            for (int i = 0; i < this.ObjectBuilder.InputNames.Count; i++)
            {
                orderedVariableNames.Add(this.Inputs[i].VariableSyntaxName(this.ObjectBuilder.InputIDs[i].VariableName));
            }
            expressions.Add(SyntaxFactory.ExpressionStatement(MySyntaxFactory.MethodInvocation(this.ObjectBuilder.TriggerName, orderedVariableNames, null)));
            base.CollectInputExpressions(expressions);
        }

        internal override void CollectSequenceExpressions(List<StatementSyntax> expressions)
        {
            this.CollectInputExpressions(expressions);
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                if (this.ObjectBuilder.SequenceInputID != -1)
                {
                    MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceInputID);
                    this.SequenceInputs.Add(nodeByID);
                }
                for (int i = 0; i < this.ObjectBuilder.InputNames.Count; i++)
                {
                    if (this.ObjectBuilder.InputIDs[i].NodeID == -1)
                    {
                        throw new Exception(string.Concat(new object[] { "TriggerNode is missing an input of ", this.ObjectBuilder.InputNames[i], " . NodeId: ", this.ObjectBuilder.ID }));
                    }
                    MyVisualSyntaxNode item = base.Navigator.GetNodeByID(this.ObjectBuilder.InputIDs[i].NodeID);
                    this.Inputs.Add(item);
                }
            }
            base.Preprocess(currentDepth);
        }

        public MyObjectBuilder_TriggerScriptNode ObjectBuilder =>
            ((MyObjectBuilder_TriggerScriptNode) base.m_objectBuilder);
    }
}


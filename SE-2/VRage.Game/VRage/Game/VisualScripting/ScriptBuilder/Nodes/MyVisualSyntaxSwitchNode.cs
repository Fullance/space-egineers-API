namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Collections.Generic;
    using VRage.Game;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxSwitchNode : MyVisualSyntaxNode
    {
        private readonly List<MyVisualSyntaxNode> m_sequenceOutputs;
        private MyVisualSyntaxNode m_valueInput;

        public MyVisualSyntaxSwitchNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
            this.m_sequenceOutputs = new List<MyVisualSyntaxNode>();
        }

        internal override void CollectSequenceExpressions(List<StatementSyntax> expressions)
        {
            this.CollectInputExpressions(expressions);
            string name = this.m_valueInput.VariableSyntaxName(this.ObjectBuilder.ValueInput.VariableName);
            List<SwitchSectionSyntax> list = new List<SwitchSectionSyntax>();
            List<StatementSyntax> list2 = new List<StatementSyntax>();
            for (int i = 0; i < this.m_sequenceOutputs.Count; i++)
            {
                MyVisualSyntaxNode node = this.m_sequenceOutputs[i];
                if (node != null)
                {
                    list2.Clear();
                    node.CollectSequenceExpressions(list2);
                    list2.Add(SyntaxFactory.BreakStatement());
                    SwitchSectionSyntax syntax = SyntaxFactory.SwitchSection().WithLabels(SyntaxFactory.SingletonList<SwitchLabelSyntax>(SyntaxFactory.CaseSwitchLabel(MySyntaxFactory.Literal(this.ObjectBuilder.NodeType, this.ObjectBuilder.Options[i].Option)))).WithStatements(SyntaxFactory.List<StatementSyntax>(list2));
                    list.Add(syntax);
                }
            }
            SwitchStatementSyntax item = SyntaxFactory.SwitchStatement(SyntaxFactory.IdentifierName(name)).WithSections(SyntaxFactory.List<SwitchSectionSyntax>(list));
            expressions.Add(item);
        }

        protected internal override void Preprocess(int currentDepth)
        {
            Action<MyVisualSyntaxNode> action = null;
            if (!base.Preprocessed)
            {
                base.TryRegisterNode(this.ObjectBuilder.SequenceInput, this.SequenceInputs);
                this.m_valueInput = base.TryRegisterNode(this.ObjectBuilder.ValueInput.NodeID, this.Inputs);
                foreach (MyObjectBuilder_SwitchScriptNode.OptionData data in this.ObjectBuilder.Options)
                {
                    if (data.SequenceOutput != -1)
                    {
                        MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(data.SequenceOutput);
                        if (nodeByID != null)
                        {
                            this.m_sequenceOutputs.Add(nodeByID);
                        }
                    }
                }
                if (action == null)
                {
                    action = node => node.Preprocess(currentDepth + 1);
                }
                this.m_sequenceOutputs.ForEach(action);
            }
            base.Preprocess(currentDepth);
        }

        internal override void Reset()
        {
            base.Reset();
            this.m_sequenceOutputs.Clear();
        }

        public MyObjectBuilder_SwitchScriptNode ObjectBuilder =>
            ((MyObjectBuilder_SwitchScriptNode) base.m_objectBuilder);
    }
}


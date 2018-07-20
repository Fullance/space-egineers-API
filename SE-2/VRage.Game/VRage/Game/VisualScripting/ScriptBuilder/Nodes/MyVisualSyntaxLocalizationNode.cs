namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.Game.VisualScripting;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxLocalizationNode : MyVisualSyntaxNode
    {
        private readonly List<MyVisualSyntaxNode> m_inputParameterNodes;

        public MyVisualSyntaxLocalizationNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
            this.m_inputParameterNodes = new List<MyVisualSyntaxNode>();
        }

        internal override void CollectInputExpressions(List<StatementSyntax> expressions)
        {
            base.CollectInputExpressions(expressions);
            SyntaxNodeOrToken[] tokenArray = new SyntaxNodeOrToken[] { SyntaxFactory.Argument(MySyntaxFactory.Literal(typeof(string).Signature(), this.ObjectBuilder.Context)), SyntaxFactory.Token(SyntaxKind.CommaToken), SyntaxFactory.Argument(MySyntaxFactory.Literal(typeof(string).Signature(), this.ObjectBuilder.MessageId)) };
            ElementAccessExpressionSyntax expression = SyntaxFactory.ElementAccessExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("VRage.Game.Localization.MyLocalization"), SyntaxFactory.IdentifierName("Static"))).WithArgumentList(SyntaxFactory.BracketedArgumentList(SyntaxFactory.SeparatedList<ArgumentSyntax>(tokenArray)));
            InvocationExpressionSyntax initializer = SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expression, SyntaxFactory.IdentifierName("ToString")));
            string variableName = "localizedText_" + this.ObjectBuilder.ID;
            if (this.m_inputParameterNodes.Count == 0)
            {
                variableName = this.VariableSyntaxName(null);
            }
            LocalDeclarationStatementSyntax item = MySyntaxFactory.LocalVariable(typeof(string).Signature(), variableName, initializer);
            if (this.m_inputParameterNodes.Count > 0)
            {
                List<string> orderedVariableNames = new List<string> {
                    variableName
                };
                for (int i = 0; i < this.m_inputParameterNodes.Count; i++)
                {
                    MyVisualSyntaxNode node = this.m_inputParameterNodes[i];
                    orderedVariableNames.Add(node.VariableSyntaxName(this.ObjectBuilder.ParameterInputs[i].VariableName));
                }
                InvocationExpressionSyntax syntax4 = MySyntaxFactory.MethodInvocation("Format", orderedVariableNames, "string");
                LocalDeclarationStatementSyntax syntax5 = MySyntaxFactory.LocalVariable(typeof(string).Signature(), this.VariableSyntaxName(null), syntax4);
                expressions.Add(item);
                expressions.Add(syntax5);
            }
            else
            {
                expressions.Add(item);
            }
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                foreach (MyVariableIdentifier identifier in this.ObjectBuilder.ValueOutputs)
                {
                    base.TryRegisterNode(identifier.NodeID, this.Outputs);
                }
                foreach (MyVariableIdentifier identifier2 in this.ObjectBuilder.ParameterInputs)
                {
                    MyVisualSyntaxNode item = base.TryRegisterNode(identifier2.NodeID, this.Inputs);
                    if (item != null)
                    {
                        this.m_inputParameterNodes.Add(item);
                    }
                }
            }
            base.Preprocess(currentDepth);
        }

        internal override void Reset()
        {
            base.Reset();
            this.m_inputParameterNodes.Clear();
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null) => 
            ("localizationNode_" + this.ObjectBuilder.ID);

        public MyObjectBuilder_LocalizationScriptNode ObjectBuilder =>
            ((MyObjectBuilder_LocalizationScriptNode) base.m_objectBuilder);

        internal override bool SequenceDependent =>
            false;
    }
}


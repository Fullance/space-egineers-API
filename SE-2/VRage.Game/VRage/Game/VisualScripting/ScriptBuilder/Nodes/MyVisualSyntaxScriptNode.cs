namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxScriptNode : MyVisualSyntaxNode
    {
        private readonly string m_instanceName;

        public MyVisualSyntaxScriptNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
            this.m_instanceName = "m_scriptInstance_" + this.ObjectBuilder.ID;
        }

        internal override void CollectInputExpressions(List<StatementSyntax> expressions)
        {
            base.CollectInputExpressions(expressions);
            expressions.AddRange((IEnumerable<StatementSyntax>) (from outputData in this.ObjectBuilder.Outputs select MySyntaxFactory.LocalVariable(outputData.Type, outputData.Name, null)));
        }

        internal override void CollectSequenceExpressions(List<StatementSyntax> expressions)
        {
            this.CollectInputExpressions(expressions);
            List<StatementSyntax> list = new List<StatementSyntax>();
            foreach (MyVisualSyntaxNode node in this.SequenceOutputs)
            {
                node.CollectSequenceExpressions(list);
            }
            StatementSyntax item = this.CreateScriptInvocationSyntax(list);
            expressions.Add(item);
        }

        private StatementSyntax CreateScriptInvocationSyntax(List<StatementSyntax> dependentStatements)
        {
            List<string> orderedVariableNames = this.ObjectBuilder.Inputs.Select<MyInputParameterSerializationData, string>(((Func<MyInputParameterSerializationData, int, string>) ((t, index) => this.Inputs[index].VariableSyntaxName(t.Input.VariableName)))).ToList<string>();
            InvocationExpressionSyntax expression = MySyntaxFactory.MethodInvocation("RunScript", orderedVariableNames, this.m_instanceName);
            if (dependentStatements == null)
            {
                return SyntaxFactory.ExpressionStatement(expression);
            }
            return MySyntaxFactory.IfExpressionSyntax(expression, dependentStatements, null);
        }

        public StatementSyntax DisposeCallDeclaration() => 
            SyntaxFactory.ExpressionStatement(MySyntaxFactory.MethodInvocation("Dispose", null, this.m_instanceName));

        public MemberDeclarationSyntax InstanceDeclaration() => 
            SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName(this.ObjectBuilder.Name)).WithVariables(SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(this.m_instanceName)).WithInitializer(SyntaxFactory.EqualsValueClause(SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName(this.ObjectBuilder.Name)).WithArgumentList(SyntaxFactory.ArgumentList(new SeparatedSyntaxList<ArgumentSyntax>())))))));

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                if (this.ObjectBuilder.SequenceOutput != -1)
                {
                    MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceOutput);
                    this.SequenceOutputs.Add(nodeByID);
                }
                if (this.ObjectBuilder.SequenceInput != -1)
                {
                    MyVisualSyntaxNode item = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceInput);
                    this.SequenceInputs.Add(item);
                }
                foreach (MyInputParameterSerializationData data in this.ObjectBuilder.Inputs)
                {
                    if (data.Input.NodeID == -1)
                    {
                        throw new Exception("Output node missing input data. NodeID: " + this.ObjectBuilder.ID);
                    }
                    MyVisualSyntaxNode node3 = base.Navigator.GetNodeByID(data.Input.NodeID);
                    this.Inputs.Add(node3);
                }
                foreach (MyOutputParameterSerializationData data2 in this.ObjectBuilder.Outputs)
                {
                    foreach (MyVariableIdentifier identifier in data2.Outputs.Ids)
                    {
                        MyVisualSyntaxNode node4 = base.Navigator.GetNodeByID(identifier.NodeID);
                        this.Outputs.Add(node4);
                    }
                }
            }
            base.Preprocess(currentDepth);
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null) => 
            variableIdentifier;

        public MyObjectBuilder_ScriptScriptNode ObjectBuilder =>
            ((MyObjectBuilder_ScriptScriptNode) base.m_objectBuilder);
    }
}


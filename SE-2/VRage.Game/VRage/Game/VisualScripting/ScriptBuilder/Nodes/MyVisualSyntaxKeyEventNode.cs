namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using VRage.Game;
    using VRage.Game.VisualScripting;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxKeyEventNode : MyVisualSyntaxEventNode
    {
        public MyVisualSyntaxKeyEventNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        internal override void CollectSequenceExpressions(List<StatementSyntax> expressions)
        {
            if (this.ObjectBuilder.SequenceOutputID != -1)
            {
                MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.SequenceOutputID);
                List<StatementSyntax> list = new List<StatementSyntax>();
                nodeByID.CollectSequenceExpressions(list);
                List<int> keyIndexes = new List<int>();
                ParameterInfo[] parameters = base.m_fieldInfo.FieldType.GetMethod("Invoke").GetParameters();
                VisualScriptingEvent customAttribute = base.m_fieldInfo.FieldType.GetCustomAttribute<VisualScriptingEvent>();
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (i >= customAttribute.IsKey.Length)
                    {
                        break;
                    }
                    if (customAttribute.IsKey[i])
                    {
                        keyIndexes.Add(i);
                    }
                }
                IfStatementSyntax item = MySyntaxFactory.IfExpressionSyntax(this.CreateAndClauses(keyIndexes.Count - 1, keyIndexes), list, null);
                expressions.Add(item);
            }
        }

        private ExpressionSyntax CreateAndClauses(int index, List<int> keyIndexes)
        {
            LiteralExpressionSyntax right = MySyntaxFactory.Literal(this.ObjectBuilder.OuputTypes[keyIndexes[index]], this.ObjectBuilder.Keys[keyIndexes[index]]);
            if (index == 0)
            {
                return SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, SyntaxFactory.IdentifierName(this.ObjectBuilder.OutputNames[keyIndexes[index]]), right);
            }
            BinaryExpressionSyntax syntax2 = SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, SyntaxFactory.IdentifierName(this.ObjectBuilder.OutputNames[keyIndexes[index]]), right);
            return SyntaxFactory.BinaryExpression(SyntaxKind.LogicalAndExpression, this.CreateAndClauses(--index, keyIndexes), syntax2);
        }

        public MyObjectBuilder_KeyEventScriptNode ObjectBuilder =>
            ((MyObjectBuilder_KeyEventScriptNode) base.m_objectBuilder);
    }
}


namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.VisualScripting;
    using VRage.Game.VisualScripting.Utils;
    using VRageMath;

    public class MyVisualSyntaxConstantNode : MyVisualSyntaxNode
    {
        public MyVisualSyntaxConstantNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
        }

        internal override void CollectInputExpressions(List<StatementSyntax> expressions)
        {
            string name = this.ObjectBuilder.Value ?? string.Empty;
            Type type = MyVisualScriptingProxy.GetType(this.ObjectBuilder.Type);
            base.CollectInputExpressions(expressions);
            if ((type == typeof(Color)) || type.IsEnum)
            {
                expressions.Add(MySyntaxFactory.LocalVariable(this.ObjectBuilder.Type, this.VariableSyntaxName(null), SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(this.ObjectBuilder.Type), SyntaxFactory.IdentifierName(name))));
            }
            else if (type == typeof(Vector3D))
            {
                expressions.Add(MySyntaxFactory.LocalVariable(this.ObjectBuilder.Type, this.VariableSyntaxName(null), MySyntaxFactory.NewVector3D(name)));
            }
            else
            {
                expressions.Add(MySyntaxFactory.LocalVariable(this.ObjectBuilder.Type, this.VariableSyntaxName(null), MySyntaxFactory.Literal(this.ObjectBuilder.Type, name)));
            }
        }

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                for (int i = 0; i < this.ObjectBuilder.OutputIds.Ids.Count; i++)
                {
                    MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(this.ObjectBuilder.OutputIds.Ids[i].NodeID);
                    if (nodeByID != null)
                    {
                        this.Outputs.Add(nodeByID);
                    }
                }
            }
            base.Preprocess(currentDepth);
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null) => 
            ("constantNode_" + this.ObjectBuilder.ID);

        public MyObjectBuilder_ConstantScriptNode ObjectBuilder =>
            ((MyObjectBuilder_ConstantScriptNode) base.m_objectBuilder);

        internal override bool SequenceDependent =>
            false;
    }
}


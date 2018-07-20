namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.VisualScripting;
    using VRage.Game.VisualScripting.Utils;
    using VRageMath;

    public class MyVisualSyntaxVariableNode : MyVisualSyntaxNode
    {
        private readonly Type m_variableType;

        public MyVisualSyntaxVariableNode(MyObjectBuilder_ScriptNode ob) : base(ob)
        {
            this.m_variableType = MyVisualScriptingProxy.GetType(this.ObjectBuilder.VariableType);
            this.Using = MySyntaxFactory.UsingStatementSyntax(this.m_variableType.Namespace);
        }

        public FieldDeclarationSyntax CreateFieldDeclaration() => 
            MySyntaxFactory.GenericFieldDeclaration(this.m_variableType, this.ObjectBuilder.VariableName, null);

        public ExpressionStatementSyntax CreateInitializationSyntax()
        {
            if (this.m_variableType.IsGenericType)
            {
                ObjectCreationExpressionSyntax rightSide = MySyntaxFactory.GenericObjectCreation(this.m_variableType, null);
                return SyntaxFactory.ExpressionStatement(MySyntaxFactory.VariableAssignment(this.ObjectBuilder.VariableName, rightSide));
            }
            if (this.m_variableType == typeof(Vector3D))
            {
                return MySyntaxFactory.VectorAssignmentExpression(this.ObjectBuilder.VariableName, this.ObjectBuilder.VariableType, this.ObjectBuilder.Vector.X, this.ObjectBuilder.Vector.Y, this.ObjectBuilder.Vector.Z);
            }
            if (this.m_variableType == typeof(string))
            {
                return MySyntaxFactory.VariableAssignmentExpression(this.ObjectBuilder.VariableName, this.ObjectBuilder.VariableValue, SyntaxKind.StringLiteralExpression);
            }
            if (this.m_variableType == typeof(bool))
            {
                SyntaxKind expressionKind = (MySyntaxFactory.NormalizeBool(this.ObjectBuilder.VariableValue) == "true") ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression;
                return MySyntaxFactory.VariableAssignmentExpression(this.ObjectBuilder.VariableName, this.ObjectBuilder.VariableValue, expressionKind);
            }
            return MySyntaxFactory.VariableAssignmentExpression(this.ObjectBuilder.VariableName, this.ObjectBuilder.VariableValue, SyntaxKind.NumericLiteralExpression);
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null) => 
            this.ObjectBuilder.VariableName;

        public MyObjectBuilder_VariableScriptNode ObjectBuilder =>
            ((MyObjectBuilder_VariableScriptNode) base.m_objectBuilder);

        internal override bool SequenceDependent =>
            false;

        public UsingDirectiveSyntax Using { get; private set; }
    }
}


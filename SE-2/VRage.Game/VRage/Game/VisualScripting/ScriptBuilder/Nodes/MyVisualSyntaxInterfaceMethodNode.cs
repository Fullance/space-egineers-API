namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.Game.VisualScripting.Utils;

    public class MyVisualSyntaxInterfaceMethodNode : MyVisualSyntaxNode, IMyVisualSyntaxEntryPoint
    {
        private readonly MethodInfo m_method;

        public MyVisualSyntaxInterfaceMethodNode(MyObjectBuilder_ScriptNode ob, Type baseClass) : base(ob)
        {
            this.m_method = baseClass.GetMethod(this.ObjectBuilder.MethodName);
        }

        public void AddSequenceInput(MyVisualSyntaxNode parent)
        {
        }

        public MethodDeclarationSyntax GetMethodDeclaration() => 
            MySyntaxFactory.PublicMethodDeclaration(this.m_method.Name, SyntaxKind.VoidKeyword, this.ObjectBuilder.OutputNames, this.ObjectBuilder.OuputTypes, null, null);

        protected internal override void Preprocess(int currentDepth)
        {
            if (!base.Preprocessed)
            {
                foreach (int num in this.ObjectBuilder.SequenceOutputIDs)
                {
                    MyVisualSyntaxNode nodeByID = base.Navigator.GetNodeByID(num);
                    this.SequenceOutputs.Add(nodeByID);
                }
            }
            base.Preprocess(currentDepth);
        }

        protected internal override string VariableSyntaxName(string variableIdentifier = null)
        {
            foreach (string str in this.ObjectBuilder.OutputNames)
            {
                if (str == variableIdentifier)
                {
                    return variableIdentifier;
                }
            }
            return null;
        }

        public MyObjectBuilder_InterfaceMethodNode ObjectBuilder =>
            ((MyObjectBuilder_InterfaceMethodNode) base.m_objectBuilder);
    }
}


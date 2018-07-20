namespace VRage.Game.VisualScripting.Utils
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Runtime.CompilerServices;

    public static class MyRoslynExtensions
    {
        public static ClassDeclarationSyntax DeclaringClass(this MethodDeclarationSyntax methodSyntax)
        {
            if (methodSyntax.Parent is ClassDeclarationSyntax)
            {
                return (methodSyntax.Parent as ClassDeclarationSyntax);
            }
            return null;
        }

        public static bool IsBool(this ITypeSymbol symbol) => 
            (symbol?.MetadataName == "Boolean");

        public static bool IsDerivedTypeOf(this ITypeSymbol derivedType, ITypeSymbol type) => 
            IsDerivedTypeRecursive(derivedType, type);

        private static bool IsDerivedTypeRecursive(ITypeSymbol derivedType, ITypeSymbol type)
        {
            if (derivedType == type)
            {
                return true;
            }
            if (derivedType.BaseType == null)
            {
                return false;
            }
            return IsDerivedTypeRecursive(derivedType.BaseType, type);
        }

        public static bool IsFloat(this ITypeSymbol symbol) => 
            (symbol?.MetadataName == "Single");

        public static bool IsInt(this ITypeSymbol symbol)
        {
            if (symbol == null)
            {
                return false;
            }
            if (symbol.MetadataName != "Int32")
            {
                return (symbol.MetadataName == "Int64");
            }
            return true;
        }

        public static bool IsOut(this ParameterSyntax paramSyntax) => 
            paramSyntax.Modifiers.Any(SyntaxKind.OutKeyword);

        public static bool IsSequenceDependent(this MethodDeclarationSyntax methodSyntax)
        {
            if (methodSyntax.AttributeLists.Count > 0)
            {
                SeparatedSyntaxList<AttributeSyntax>.Enumerator enumerator = methodSyntax.AttributeLists.First().Attributes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    AttributeSyntax current = enumerator.Current;
                    if (current.Name.ToString() == "VisualScriptingMember")
                    {
                        return (current.ArgumentList?.Arguments.First().Expression.Kind() == SyntaxKind.TrueLiteralExpression);
                    }
                }
            }
            return false;
        }

        public static bool IsStatic(this MethodDeclarationSyntax methodSyntax) => 
            methodSyntax.Modifiers.Any(SyntaxKind.StaticKeyword);

        public static bool IsString(this ITypeSymbol symbol) => 
            (symbol?.MetadataName == "String");

        public static bool LiteComparator(this ITypeSymbol current, ITypeSymbol another) => 
            (current.Name == another.Name);

        public static string SerializeToObjectBuilder(this MethodDeclarationSyntax syntax)
        {
            ClassDeclarationSyntax syntax2 = syntax.DeclaringClass();
            NamespaceDeclarationSyntax parent = syntax2.Parent as NamespaceDeclarationSyntax;
            return string.Concat(new object[] { parent.Name, ".", syntax2.Identifier.Text, ".", syntax.Identifier.Text, syntax.ParameterList.ToFullString() });
        }

        public static string SerializeToObjectBuilder(this ITypeSymbol typeSymbol) => 
            (typeSymbol.ContainingNamespace.Name + "." + typeSymbol.MetadataName);
    }
}


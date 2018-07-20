namespace VRage.Game.VisualScripting.ScriptBuilder
{
    using Microsoft.CodeAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using VRage.Collections;

    public class MyDependencyCollector
    {
        private HashSet<MetadataReference> m_references;

        public MyDependencyCollector()
        {
            this.m_references = new HashSet<MetadataReference>();
        }

        public MyDependencyCollector(IEnumerable<Assembly> assemblies) : this()
        {
            foreach (Assembly assembly in assemblies)
            {
                this.CollectReferences(assembly);
            }
        }

        public void CollectReferences(Assembly assembly)
        {
            if (assembly != null)
            {
                foreach (AssemblyName name in assembly.GetReferencedAssemblies())
                {
                    Assembly assembly2 = Assembly.Load(name);
                    MetadataReferenceProperties properties = new MetadataReferenceProperties();
                    this.m_references.Add(MetadataReference.CreateFromFile(assembly2.Location, properties, null));
                }
                this.m_references.Add(MetadataReference.CreateFromFile(assembly.Location, new MetadataReferenceProperties(), null));
            }
        }

        public void RegisterAssembly(Assembly assembly)
        {
            if (assembly != null)
            {
                this.m_references.Add(MetadataReference.CreateFromFile(assembly.Location, new MetadataReferenceProperties(), null));
            }
        }

        public HashSetReader<MetadataReference> References =>
            new HashSetReader<MetadataReference>(this.m_references);
    }
}


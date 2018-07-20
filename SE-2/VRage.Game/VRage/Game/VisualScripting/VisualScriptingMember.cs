namespace VRage.Game.VisualScripting
{
    using System;
    using System.Runtime.InteropServices;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Class, Inherited=false, AllowMultiple=true)]
    public class VisualScriptingMember : Attribute
    {
        public readonly bool Reserved;
        public readonly bool Sequential;

        public VisualScriptingMember(bool isSequenceDependent = false, bool reserved = false)
        {
            this.Sequential = isSequenceDependent;
            this.Reserved = reserved;
        }
    }
}


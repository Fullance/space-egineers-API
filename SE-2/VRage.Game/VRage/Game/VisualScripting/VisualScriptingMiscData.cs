namespace VRage.Game.VisualScripting
{
    using System;
    using System.Runtime.InteropServices;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Class, Inherited=false, AllowMultiple=true)]
    public class VisualScriptingMiscData : Attribute
    {
        public readonly string Comment;
        public readonly string Group;

        public VisualScriptingMiscData(string group, string comment = null)
        {
            this.Group = group;
            this.Comment = comment;
        }
    }
}


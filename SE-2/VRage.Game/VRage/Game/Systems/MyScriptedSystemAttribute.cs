namespace VRage.Game.Systems
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class MyScriptedSystemAttribute : Attribute
    {
        public readonly string ScriptName;

        public MyScriptedSystemAttribute(string scriptName)
        {
            this.ScriptName = scriptName;
        }
    }
}


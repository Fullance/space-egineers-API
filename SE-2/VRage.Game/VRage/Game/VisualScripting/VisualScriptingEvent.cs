namespace VRage.Game.VisualScripting
{
    using System;
    using System.Runtime.InteropServices;

    [AttributeUsage(AttributeTargets.Delegate, AllowMultiple=true)]
    public class VisualScriptingEvent : Attribute
    {
        public readonly bool[] IsKey;

        public VisualScriptingEvent(bool firstParam = false)
        {
            this.IsKey = new bool[] { firstParam };
        }

        public VisualScriptingEvent(bool[] @params)
        {
            this.IsKey = @params;
        }

        public bool HasKeys
        {
            get
            {
                bool[] isKey = this.IsKey;
                for (int i = 0; i < isKey.Length; i++)
                {
                    if (isKey[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}


namespace VRage.Game.VisualScripting.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using VRage.Game.VisualScripting;

    public static class MyVSCollectionExtensions
    {
        [VisualScriptingMember(false, false)]
        public static T At<T>(this List<T> list, int index)
        {
            if ((index >= 0) && (index < list.Count))
            {
                return list[index];
            }
            return default(T);
        }

        [VisualScriptingMember(false, false)]
        public static int Count<T>(this List<T> list) => 
            list.Count;
    }
}


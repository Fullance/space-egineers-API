namespace VRage.Game.ModAPI.Ingame.Utilities
{
    using System;
    using System.Collections.Generic;
    using VRage.Utils;

    internal class StringSegmentIgnoreCaseComparer : IEqualityComparer<StringSegment>
    {
        public static readonly StringSegmentIgnoreCaseComparer DEFAULT = new StringSegmentIgnoreCaseComparer();

        public bool Equals(StringSegment x, StringSegment y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            string text = x.Text;
            int start = x.Start;
            string str2 = y.Text;
            int num2 = y.Start;
            for (int i = 0; i < x.Length; i++)
            {
                if (char.ToUpperInvariant(text[start]) != char.ToUpperInvariant(str2[num2]))
                {
                    return false;
                }
                start++;
                num2++;
            }
            return true;
        }

        public int GetHashCode(StringSegment obj) => 
            MyUtils.GetHashUpperCase(obj.Text, obj.Start, obj.Length, -2128831035);
    }
}


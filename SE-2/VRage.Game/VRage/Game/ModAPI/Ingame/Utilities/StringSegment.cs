namespace VRage.Game.ModAPI.Ingame.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct StringSegment
    {
        private static readonly char[] NEWLINE_CHARS;
        public readonly string Text;
        public readonly int Start;
        public readonly int Length;
        private string m_cache;
        public StringSegment(string text) : this(text, 0, text.Length)
        {
            this.m_cache = text;
        }

        public StringSegment(string text, int start, int length)
        {
            this.Text = text;
            this.Start = start;
            this.Length = Math.Max(0, length);
            this.m_cache = null;
        }

        public bool IsEmpty =>
            (this.Text == null);
        public bool IsCached =>
            (this.m_cache != null);
        public int IndexOf(char ch)
        {
            if (this.Length == 0)
            {
                return -1;
            }
            return this.Text.IndexOf(ch, this.Start, this.Length);
        }

        public int IndexOf(char ch, int start)
        {
            if (this.Length == 0)
            {
                return -1;
            }
            return this.Text.IndexOf(ch, this.Start + start, this.Length);
        }

        public int IndexOfAny(char[] chars)
        {
            if (this.Length == 0)
            {
                return -1;
            }
            return this.Text.IndexOfAny(chars, this.Start, this.Length);
        }

        public bool EqualsIgnoreCase(StringSegment other)
        {
            if (this.Length != other.Length)
            {
                return false;
            }
            string text = this.Text;
            int start = this.Start;
            string str2 = other.Text;
            int num2 = other.Start;
            for (int i = 0; i < this.Length; i++)
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

        public override string ToString()
        {
            if (this.Length == 0)
            {
                return "";
            }
            if (this.m_cache == null)
            {
                this.m_cache = this.Text.Substring(this.Start, this.Length);
            }
            return this.m_cache;
        }

        public char this[int i]
        {
            get
            {
                if ((i >= 0) && (i < this.Length))
                {
                    return this.Text[this.Start + i];
                }
                return '\0';
            }
        }
        public void GetLines(List<string> lines)
        {
            if (this.Length != 0)
            {
                string text = this.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    int start = this.Start;
                    int num2 = start + this.Length;
                    lines.Clear();
                    while (start < num2)
                    {
                        int num3 = text.IndexOfAny(NEWLINE_CHARS, start, num2 - start);
                        if (num3 < 0)
                        {
                            lines.Add(text.Substring(start, text.Length - start));
                            return;
                        }
                        lines.Add(text.Substring(start, num3 - start));
                        start = num3;
                        if ((start < text.Length) && (text[start] == '\r'))
                        {
                            start++;
                        }
                        if ((start < text.Length) && (text[start] == '\n'))
                        {
                            start++;
                        }
                    }
                }
            }
        }

        static StringSegment()
        {
            NEWLINE_CHARS = new char[] { '\r', '\n' };
        }
    }
}


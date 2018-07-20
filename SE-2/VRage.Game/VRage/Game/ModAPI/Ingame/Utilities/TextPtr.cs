namespace VRage.Game.ModAPI.Ingame.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    [StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ToDebugString(),nq}")]
    public struct TextPtr
    {
        public readonly string Content;
        public readonly int Index;
        public static implicit operator int(TextPtr ptr) => 
            ptr.Index;

        public static implicit operator string(TextPtr ptr) => 
            ptr.Content;

        public static TextPtr operator +(TextPtr ptr, int offset) => 
            new TextPtr(ptr.Content, ptr.Index + offset);

        public static TextPtr operator ++(TextPtr ptr) => 
            new TextPtr(ptr.Content, ptr.Index + 1);

        public static TextPtr operator -(TextPtr ptr, int offset) => 
            new TextPtr(ptr.Content, ptr.Index - offset);

        public static TextPtr operator --(TextPtr ptr) => 
            new TextPtr(ptr.Content, ptr.Index - 1);

        public TextPtr(string content)
        {
            this.Content = content;
            this.Index = 0;
        }

        public TextPtr(string content, int index)
        {
            this.Content = content;
            this.Index = index;
        }

        public bool IsOutOfBounds()
        {
            if (this.Index >= 0)
            {
                return (this.Index >= this.Content.Length);
            }
            return true;
        }

        public char Char
        {
            get
            {
                if (!this.IsOutOfBounds())
                {
                    return this.Content[this.Index];
                }
                return '\0';
            }
        }
        public bool IsEmpty =>
            (this.Content != null);
        public int FindLineNo()
        {
            string content = this.Content;
            int index = this.Index;
            int num2 = 1;
            for (int i = 0; i < index; i++)
            {
                if (content[i] == '\n')
                {
                    num2++;
                }
            }
            return num2;
        }

        public TextPtr Find(string str)
        {
            if (this.IsOutOfBounds())
            {
                return this;
            }
            int index = this.Content.IndexOf(str, this.Index, StringComparison.InvariantCulture);
            if (index == -1)
            {
                return new TextPtr(this.Content, this.Content.Length);
            }
            return new TextPtr(this.Content, index);
        }

        public TextPtr Find(char ch)
        {
            if (this.IsOutOfBounds())
            {
                return this;
            }
            int index = this.Content.IndexOf(ch, this.Index);
            if (index == -1)
            {
                return new TextPtr(this.Content, this.Content.Length);
            }
            return new TextPtr(this.Content, index);
        }

        public TextPtr FindInLine(char ch)
        {
            if (this.IsOutOfBounds())
            {
                return this;
            }
            string content = this.Content;
            int length = this.Content.Length;
            for (int i = this.Index; i < length; i++)
            {
                char ch2 = content[i];
                if (ch2 == ch)
                {
                    return new TextPtr(content, i);
                }
                if ((ch2 == '\r') || (ch2 == '\n'))
                {
                    break;
                }
            }
            return new TextPtr(this.Content, this.Content.Length);
        }

        public TextPtr FindEndOfLine(bool skipNewline = false)
        {
            int length = this.Content.Length;
            if (this.Index >= length)
            {
                return this;
            }
            TextPtr ptr = this;
            while (ptr.Index < length)
            {
                if (ptr.IsNewLine())
                {
                    if (!skipNewline)
                    {
                        return ptr;
                    }
                    if (ptr.Char == '\r')
                    {
                        ptr = op_Increment(ptr);
                    }
                    return op_Increment(ptr);
                }
                ptr = op_Increment(ptr);
            }
            return ptr;
        }

        public bool StartsWithCaseInsensitive(string what)
        {
            TextPtr ptr = this;
            foreach (char ch in what)
            {
                if (char.ToUpper(ptr.Char) != char.ToUpper(ch))
                {
                    return false;
                }
                ptr = op_Increment(ptr);
            }
            return true;
        }

        public bool StartsWith(string what)
        {
            TextPtr ptr = this;
            foreach (char ch in what)
            {
                if (ptr.Char != ch)
                {
                    return false;
                }
                ptr = op_Increment(ptr);
            }
            return true;
        }

        public TextPtr SkipWhitespace(bool skipNewline = false)
        {
            TextPtr ptr = this;
            int length = ptr.Content.Length;
            if (skipNewline)
            {
                while (true)
                {
                    char c = ptr.Char;
                    if ((ptr.Index >= length) || !char.IsWhiteSpace(c))
                    {
                        return ptr;
                    }
                    ptr = op_Increment(ptr);
                }
            }
            while (true)
            {
                char ch2 = ptr.Char;
                if (((ptr.Index >= length) || ptr.IsNewLine()) || !char.IsWhiteSpace(ch2))
                {
                    return ptr;
                }
                ptr = op_Increment(ptr);
            }
        }

        public bool IsEndOfLine()
        {
            if (this.Index < this.Content.Length)
            {
                return this.IsNewLine();
            }
            return true;
        }

        public bool IsStartOfLine()
        {
            if (this.Index > 0)
            {
                TextPtr ptr = this - 1;
                return ptr.IsNewLine();
            }
            return true;
        }

        public bool IsNewLine()
        {
            char ch = this.Char;
            if (ch == '\n')
            {
                return true;
            }
            if (ch != '\r')
            {
                return false;
            }
            return ((this.Index < (this.Content.Length - 1)) && (this.Content[this.Index + 1] == '\n'));
        }

        public TextPtr TrimStart()
        {
            string content = this.Content;
            int index = this.Index;
            int length = content.Length;
            while (index < length)
            {
                char ch = content[index];
                if ((ch != ' ') && (ch != '\t'))
                {
                    break;
                }
                index++;
            }
            return new TextPtr(content, index);
        }

        public TextPtr TrimEnd()
        {
            string content = this.Content;
            int num = this.Index - 1;
            while (num >= 0)
            {
                char ch = content[num];
                if ((ch != ' ') && (ch != '\t'))
                {
                    break;
                }
                num--;
            }
            return new TextPtr(content, num + 1);
        }

        private string ToDebugString()
        {
            string str;
            if (this.Index < 0)
            {
                return "<before>";
            }
            if (this.Index >= this.Content.Length)
            {
                return "<after>";
            }
            int num = this.Index + 0x25;
            if (num > this.Content.Length)
            {
                str = this.Content.Substring(this.Index, this.Content.Length - this.Index);
            }
            else
            {
                str = this.Content.Substring(this.Index, num - this.Index) + "...";
            }
            return Regex.Replace(str, @"[\r\t\n]", delegate (Match match) {
                switch (match.Value)
                {
                    case "\r":
                        return @"\r";

                    case "\t":
                        return @"\t";

                    case "\n":
                        return @"\n";
                }
                return match.Value;
            });
        }
    }
}


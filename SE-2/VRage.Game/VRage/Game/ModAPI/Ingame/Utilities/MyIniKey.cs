namespace VRage.Game.ModAPI.Ingame.Utilities
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Utils;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyIniKey : IEquatable<MyIniKey>
    {
        private static readonly char[] INVALID_SECTION_CHARS;
        private static readonly string INVALID_SECTION_CHARS_STR;
        private static readonly char[] INVALID_KEY_CHARS;
        private static readonly string INVALID_KEY_CHARS_STR;
        public static readonly MyIniKey EMPTY;
        internal readonly StringSegment SectionSegment;
        internal readonly StringSegment NameSegment;
        internal static string ValidateSection(ref StringSegment segment)
        {
            if (segment.Length == 0)
            {
                return "cannot be empty.";
            }
            if (segment.IndexOfAny(INVALID_KEY_CHARS) >= 0)
            {
                return $"contains illegal characters ({INVALID_KEY_CHARS_STR})";
            }
            return null;
        }

        internal static string ValidateKey(ref StringSegment segment)
        {
            if (segment.Length == 0)
            {
                return "cannot be empty.";
            }
            if (segment.IndexOfAny(INVALID_KEY_CHARS) >= 0)
            {
                return $"contains illegal characters ({INVALID_KEY_CHARS_STR})";
            }
            return null;
        }

        public static bool operator ==(MyIniKey a, MyIniKey b) => 
            a.Equals(b);

        public static bool operator !=(MyIniKey a, MyIniKey b) => 
            !a.Equals(b);

        public static bool TryParse(string input, out MyIniKey key)
        {
            if (string.IsNullOrEmpty(input))
            {
                key = EMPTY;
                return false;
            }
            int index = input.IndexOf("/", StringComparison.Ordinal);
            if (index == -1)
            {
                key = EMPTY;
                return false;
            }
            string section = input.Substring(0, index).Trim();
            string name = input.Substring(index + 2).Trim();
            if (((section.Length == 0) || (section.IndexOfAny(INVALID_SECTION_CHARS) >= 0)) || ((name.Length == 0) || (name.IndexOfAny(INVALID_KEY_CHARS) >= 0)))
            {
                key = EMPTY;
                return false;
            }
            key = new MyIniKey(section, name);
            return true;
        }

        public static MyIniKey Parse(string input)
        {
            MyIniKey key;
            if (!TryParse(input, out key))
            {
                throw new ArgumentException("Invalid configuration key format", "input");
            }
            return key;
        }

        public string Section =>
            this.SectionSegment.ToString();
        public string Name =>
            this.NameSegment.ToString();
        public MyIniKey(string section, string name)
        {
            if (string.IsNullOrWhiteSpace(section))
            {
                throw new ArgumentException("Section cannot be empty.", "section");
            }
            if (section.IndexOfAny(INVALID_SECTION_CHARS) >= 0)
            {
                throw new ArgumentException($"Section contains illegal characters ({INVALID_SECTION_CHARS_STR})", "section");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Key cannot be null or whitespace.", "name");
            }
            if (name.IndexOfAny(INVALID_KEY_CHARS) >= 0)
            {
                throw new ArgumentException($"Key contains illegal characters ({INVALID_KEY_CHARS_STR})", "name");
            }
            this.SectionSegment = new StringSegment(section);
            this.NameSegment = new StringSegment(name);
        }

        internal MyIniKey(StringSegment section, StringSegment name)
        {
            this.SectionSegment = section;
            this.NameSegment = name;
        }

        public bool IsEmpty =>
            (this.NameSegment.Length == 0);
        public bool Equals(MyIniKey other)
        {
            if (!this.SectionSegment.EqualsIgnoreCase(other.SectionSegment))
            {
                return false;
            }
            if (!this.NameSegment.EqualsIgnoreCase(other.NameSegment))
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }
            return ((obj is MyIniKey) && this.Equals((MyIniKey) obj));
        }

        public override int GetHashCode() => 
            ((MyUtils.GetHashUpperCase(this.SectionSegment.Text, this.SectionSegment.Start, this.SectionSegment.Length, -2128831035) * 0x18d) ^ MyUtils.GetHashUpperCase(this.NameSegment.Text, this.NameSegment.Start, this.NameSegment.Length, -2128831035));

        public override string ToString()
        {
            if (this.IsEmpty)
            {
                return "";
            }
            return $"{this.Section}/{this.Name}";
        }

        static MyIniKey()
        {
            INVALID_SECTION_CHARS = new char[] { '\r', '\n', '[', ']' };
            INVALID_SECTION_CHARS_STR = @"\r, \n, [, ]";
            INVALID_KEY_CHARS = new char[] { '\r', '\n', '|', '=', '[', ']' };
            INVALID_KEY_CHARS_STR = @"\r, \n, |, =, [, ]";
            EMPTY = new MyIniKey();
        }
    }
}


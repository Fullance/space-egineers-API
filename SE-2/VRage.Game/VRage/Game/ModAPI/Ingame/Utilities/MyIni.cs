namespace VRage.Game.ModAPI.Ingame.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    public class MyIni
    {
        private string m_content;
        private StringSegment m_endComment;
        private StringSegment m_endContent;
        private readonly Dictionary<MyIniKey, StringSegment> m_itemComments = new Dictionary<MyIniKey, StringSegment>(MyIniKeyComparer.DEFAULT);
        private readonly Dictionary<MyIniKey, StringSegment> m_items = new Dictionary<MyIniKey, StringSegment>(MyIniKeyComparer.DEFAULT);
        private readonly Dictionary<StringSegment, StringSegment> m_sectionComments = new Dictionary<StringSegment, StringSegment>(StringSegmentIgnoreCaseComparer.DEFAULT);
        private int m_sectionCounter;
        private readonly Dictionary<StringSegment, int> m_sections = new Dictionary<StringSegment, int>(StringSegmentIgnoreCaseComparer.DEFAULT);
        private StringBuilder m_tmpContentBuilder;
        private List<MyIniKey> m_tmpKeyList;
        private List<string> m_tmpStringList;
        private StringBuilder m_tmpValueBuilder;

        private void AddSection(ref StringSegment section)
        {
            if (!this.m_sections.ContainsKey(section))
            {
                this.m_sections[section] = this.m_sectionCounter;
                this.m_sectionCounter++;
            }
        }

        public void Clear()
        {
            this.m_items.Clear();
            this.m_sections.Clear();
            this.m_content = null;
            this.m_sectionCounter = 0;
            this.m_endContent = new StringSegment();
            if (this.m_tmpContentBuilder != null)
            {
                this.m_tmpContentBuilder.Clear();
            }
            if (this.m_tmpValueBuilder != null)
            {
                this.m_tmpValueBuilder.Clear();
            }
            if (this.m_tmpKeyList != null)
            {
                this.m_tmpKeyList.Clear();
            }
            if (this.m_tmpStringList != null)
            {
                this.m_tmpStringList.Clear();
            }
        }

        public bool ContainsKey(MyIniKey key) => 
            this.m_items.ContainsKey(key);

        public bool ContainsKey(string section, string name) => 
            this.ContainsKey(new MyIniKey(section, name));

        public bool ContainsSection(string section) => 
            this.m_sections.ContainsKey(new StringSegment(section));

        public void Delete(MyIniKey key)
        {
            if (key.IsEmpty)
            {
                throw new ArgumentException("Key cannot be empty", "key");
            }
            this.m_items.Remove(key);
            this.m_content = null;
        }

        public void Delete(string section, string name)
        {
            this.Delete(new MyIniKey(section, name));
            this.m_content = null;
        }

        private static int FindSection(string config, string section)
        {
            TextPtr ptr = new TextPtr(config);
            if (!MatchesSection(ref ptr, section))
            {
                while (!ptr.IsOutOfBounds())
                {
                    ptr = TextPtr.op_Increment(ptr.Find("\n"));
                    if (ptr.Char == '[')
                    {
                        if (MatchesSection(ref ptr, section))
                        {
                            return ptr.Index;
                        }
                    }
                    else if (ptr.StartsWith("---"))
                    {
                        ptr = (ptr + 3).SkipWhitespace(false);
                        if (ptr.IsEndOfLine())
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                return ptr.Index;
            }
            return -1;
        }

        private string GenerateContent()
        {
            Func<StringSegment, int> keySelector = null;
            string str6;
            StringBuilder tmpContentBuilder = this.TmpContentBuilder;
            List<MyIniKey> tmpKeyList = this.TmpKeyList;
            List<string> tmpStringList = this.TmpStringList;
            try
            {
                StringSegment endCommentSegment;
                bool flag = false;
                if (keySelector == null)
                {
                    keySelector = s => this.m_sections[s];
                }
                foreach (StringSegment segment2 in this.m_sections.Keys.OrderBy<StringSegment, int>(keySelector))
                {
                    if (flag)
                    {
                        tmpContentBuilder.Append('\n');
                    }
                    flag = true;
                    endCommentSegment = this.GetSectionCommentSegment(segment2);
                    if (!endCommentSegment.IsEmpty)
                    {
                        endCommentSegment.GetLines(tmpStringList);
                        foreach (string str in tmpStringList)
                        {
                            tmpContentBuilder.Append(";");
                            tmpContentBuilder.Append(str);
                            tmpContentBuilder.Append('\n');
                        }
                    }
                    tmpContentBuilder.Append("[");
                    tmpContentBuilder.Append(segment2);
                    tmpContentBuilder.Append("]\n");
                    this.GetKeys(segment2, tmpKeyList);
                    for (int i = 0; i < tmpKeyList.Count; i++)
                    {
                        MyIniKey key = tmpKeyList[i];
                        StringSegment nameSegment = key.NameSegment;
                        endCommentSegment = this.GetCommentSegment(key);
                        if (!endCommentSegment.IsEmpty)
                        {
                            endCommentSegment.GetLines(tmpStringList);
                            foreach (string str2 in tmpStringList)
                            {
                                tmpContentBuilder.Append(";");
                                tmpContentBuilder.Append(str2);
                                tmpContentBuilder.Append('\n');
                            }
                        }
                        tmpContentBuilder.Append(nameSegment.Text, nameSegment.Start, nameSegment.Length);
                        tmpContentBuilder.Append('=');
                        StringSegment segment4 = this.m_items[key];
                        if (NeedsMultilineFormat(ref segment4))
                        {
                            this.Realize(ref key, ref segment4);
                            segment4.GetLines(tmpStringList);
                            tmpContentBuilder.Append('\n');
                            foreach (string str3 in tmpStringList)
                            {
                                tmpContentBuilder.Append("|");
                                tmpContentBuilder.Append(str3);
                                tmpContentBuilder.Append('\n');
                            }
                        }
                        else
                        {
                            tmpContentBuilder.Append(segment4.Text, segment4.Start, segment4.Length);
                            tmpContentBuilder.Append('\n');
                        }
                    }
                }
                endCommentSegment = this.GetEndCommentSegment();
                if (!endCommentSegment.IsEmpty)
                {
                    tmpContentBuilder.Append('\n');
                    endCommentSegment.GetLines(tmpStringList);
                    foreach (string str4 in tmpStringList)
                    {
                        tmpContentBuilder.Append(";");
                        tmpContentBuilder.Append(str4);
                        tmpContentBuilder.Append('\n');
                    }
                }
                if (this.m_endContent.Length > 0)
                {
                    tmpContentBuilder.Append('\n');
                    tmpContentBuilder.Append("---\n");
                    tmpContentBuilder.Append(this.m_endContent);
                }
                string str5 = tmpContentBuilder.ToString();
                tmpContentBuilder.Clear();
                tmpKeyList.Clear();
                str6 = str5;
            }
            finally
            {
                tmpContentBuilder.Clear();
                tmpKeyList.Clear();
            }
            return str6;
        }

        public MyIniValue Get(MyIniKey key)
        {
            StringSegment segment;
            if (this.m_items.TryGetValue(key, out segment))
            {
                this.Realize(ref key, ref segment);
                return new MyIniValue(key, segment.ToString());
            }
            return MyIniValue.EMPTY;
        }

        public MyIniValue Get(string section, string name) => 
            this.Get(new MyIniKey(section, name));

        public string GetComment(MyIniKey key)
        {
            StringSegment commentSegment = this.GetCommentSegment(key);
            if (commentSegment.IsEmpty)
            {
                return null;
            }
            return commentSegment.ToString();
        }

        public string GetComment(string section, string name) => 
            this.GetComment(new MyIniKey(section, name));

        private StringSegment GetCommentSegment(MyIniKey key)
        {
            StringSegment segment;
            if (!this.m_itemComments.TryGetValue(key, out segment))
            {
                return new StringSegment();
            }
            if (!segment.IsCached)
            {
                this.RealizeComment(ref segment);
                this.m_itemComments[key] = segment;
            }
            return segment;
        }

        private StringSegment GetEndCommentSegment()
        {
            StringSegment endComment = this.m_endComment;
            if (!endComment.IsCached)
            {
                this.RealizeComment(ref endComment);
                this.m_endComment = endComment;
            }
            return endComment;
        }

        public void GetKeys(List<MyIniKey> keys)
        {
            if (keys != null)
            {
                keys.Clear();
                foreach (MyIniKey key in this.m_items.Keys)
                {
                    keys.Add(key);
                }
            }
        }

        public void GetKeys(string section, List<MyIniKey> keys)
        {
            if (keys != null)
            {
                this.GetKeys(new StringSegment(section), keys);
            }
        }

        private void GetKeys(StringSegment section, List<MyIniKey> keys)
        {
            if (keys != null)
            {
                keys.Clear();
                foreach (MyIniKey key in this.m_items.Keys)
                {
                    if (key.SectionSegment.EqualsIgnoreCase(section))
                    {
                        keys.Add(key);
                    }
                }
            }
        }

        public string GetSectionComment(string section)
        {
            StringSegment key = new StringSegment(section);
            StringSegment sectionCommentSegment = this.GetSectionCommentSegment(key);
            if (sectionCommentSegment.IsEmpty)
            {
                return null;
            }
            return sectionCommentSegment.ToString();
        }

        private StringSegment GetSectionCommentSegment(StringSegment key)
        {
            StringSegment segment;
            if (!this.m_sectionComments.TryGetValue(key, out segment))
            {
                return new StringSegment();
            }
            if (!segment.IsCached)
            {
                this.RealizeComment(ref segment);
                this.m_sectionComments[key] = segment;
            }
            return segment;
        }

        public void GetSections(List<string> names)
        {
            if (names != null)
            {
                names.Clear();
                foreach (StringSegment segment in this.m_sections.Keys)
                {
                    names.Add(segment.ToString());
                }
            }
        }

        public static bool HasSection(string config, string section) => 
            (FindSection(config, section) >= 0);

        public void Invalidate()
        {
            this.m_content = null;
        }

        private static bool MatchesSection(ref TextPtr ptr, string section)
        {
            if (!ptr.StartsWith("["))
            {
                return false;
            }
            TextPtr ptr2 = ptr + 1;
            if (!ptr2.StartsWithCaseInsensitive(section))
            {
                return false;
            }
            ptr2 += section.Length;
            if (!ptr2.StartsWith("]"))
            {
                return false;
            }
            return true;
        }

        private static bool NeedsMultilineFormat(ref StringSegment str)
        {
            if (str.Length <= 0)
            {
                return false;
            }
            if (!char.IsWhiteSpace(str[0]) && !char.IsWhiteSpace(str[str.Length - 1]))
            {
                return (str.IndexOf('\n') >= 0);
            }
            return true;
        }

        private void ReadPrefix(ref TextPtr ptr, out StringSegment prefix)
        {
            bool flag = false;
            TextPtr ptr2 = ptr;
            while (!ptr.IsOutOfBounds())
            {
                if (ptr.IsStartOfLine() && (ptr.Char == ';'))
                {
                    if (!flag)
                    {
                        flag = true;
                        ptr2 = ptr;
                    }
                    ptr = ptr.FindEndOfLine(false);
                }
                TextPtr ptr3 = ptr.SkipWhitespace(false);
                if (!ptr3.IsNewLine())
                {
                    break;
                }
                if (ptr3.Char == '\r')
                {
                    ptr = ptr3 + 2;
                }
                else
                {
                    ptr = ptr3 + 1;
                }
            }
            if (flag)
            {
                TextPtr ptr4 = ptr;
                while (char.IsWhiteSpace(ptr4.Char) && (ptr4 > ptr2))
                {
                    ptr4 = TextPtr.op_Decrement(ptr4);
                }
                int length = ptr4.Index - ptr2.Index;
                if (length > 0)
                {
                    prefix = new StringSegment(ptr.Content, ptr2.Index, length);
                    return;
                }
            }
            prefix = new StringSegment();
        }

        private void Realize(ref MyIniKey key, ref StringSegment value)
        {
            if (!value.IsCached)
            {
                string text = value.Text;
                TextPtr ptr = new TextPtr(text, value.Start);
                if ((value.Length > 0) && ptr.IsNewLine())
                {
                    StringBuilder tmpValueBuilder = this.TmpValueBuilder;
                    try
                    {
                        ptr = TextPtr.op_Increment(ptr.FindEndOfLine(true));
                        int count = (value.Start + value.Length) - ptr.Index;
                        tmpValueBuilder.Append(text, ptr.Index, count);
                        tmpValueBuilder.Replace("\n|", "\n");
                        this.m_items[key] = value = new StringSegment(tmpValueBuilder.ToString());
                    }
                    finally
                    {
                        tmpValueBuilder.Clear();
                    }
                }
                else
                {
                    this.m_items[key] = value = new StringSegment(value.ToString());
                }
            }
        }

        private void RealizeComment(ref StringSegment comment)
        {
            if (!comment.IsCached)
            {
                string text = comment.Text;
                TextPtr ptr = new TextPtr(text, comment.Start);
                if (comment.Length > 0)
                {
                    StringBuilder tmpValueBuilder = this.TmpValueBuilder;
                    try
                    {
                        TextPtr ptr2 = ptr + comment.Length;
                        for (bool flag = false; ptr < ptr2; flag = true)
                        {
                            if (flag)
                            {
                                tmpValueBuilder.Append('\n');
                            }
                            if (ptr.Char == ';')
                            {
                                ptr = TextPtr.op_Increment(ptr);
                                TextPtr ptr3 = ptr.FindEndOfLine(false);
                                int count = ptr3.Index - ptr.Index;
                                tmpValueBuilder.Append(ptr.Content, ptr.Index, count);
                                ptr = ptr3.SkipWhitespace(false);
                                if (ptr.IsEndOfLine())
                                {
                                    if (ptr.Char == '\r')
                                    {
                                        ptr += 2;
                                    }
                                    else
                                    {
                                        ptr = TextPtr.op_Increment(ptr);
                                    }
                                }
                            }
                            else
                            {
                                ptr = ptr.SkipWhitespace(false);
                                if (!ptr.IsEndOfLine())
                                {
                                    break;
                                }
                                if (ptr.Char == '\r')
                                {
                                    ptr += 2;
                                }
                                else
                                {
                                    ptr = TextPtr.op_Increment(ptr);
                                }
                            }
                        }
                        comment = new StringSegment(tmpValueBuilder.ToString());
                    }
                    finally
                    {
                        tmpValueBuilder.Clear();
                    }
                }
            }
        }

        public void Set(MyIniKey key, bool value)
        {
            this.Set(key, value ? "true" : "false");
        }

        public void Set(MyIniKey key, byte value)
        {
            this.Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, decimal value)
        {
            this.Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, double value)
        {
            this.Set(key, value.ToString("R", CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, short value)
        {
            this.Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, int value)
        {
            this.Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, long value)
        {
            this.Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, sbyte value)
        {
            this.Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, float value)
        {
            this.Set(key, value.ToString("R", CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, string value)
        {
            if (key.IsEmpty)
            {
                throw new ArgumentException("Key cannot be empty", "key");
            }
            if (value == null)
            {
                this.Delete(key);
            }
            else
            {
                StringSegment sectionSegment = key.SectionSegment;
                this.AddSection(ref sectionSegment);
                this.m_items[key] = new StringSegment(value);
                this.m_content = null;
            }
        }

        public void Set(MyIniKey key, ushort value)
        {
            this.Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, uint value)
        {
            this.Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(MyIniKey key, ulong value)
        {
            this.Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, bool value)
        {
            this.Set(section, name, value ? "true" : "false");
        }

        public void Set(string section, string name, byte value)
        {
            this.Set(section, name, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, decimal value)
        {
            this.Set(section, name, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, double value)
        {
            this.Set(section, name, value.ToString("R", CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, short value)
        {
            this.Set(section, name, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, int value)
        {
            this.Set(section, name, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, long value)
        {
            this.Set(section, name, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, sbyte value)
        {
            this.Set(section, name, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, float value)
        {
            this.Set(section, name, value.ToString("R", CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, string value)
        {
            this.Set(new MyIniKey(section, name), value);
        }

        public void Set(string section, string name, ushort value)
        {
            this.Set(section, name, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, uint value)
        {
            this.Set(section, name, value.ToString(CultureInfo.InvariantCulture));
        }

        public void Set(string section, string name, ulong value)
        {
            this.Set(section, name, value.ToString(CultureInfo.InvariantCulture));
        }

        public void SetComment(MyIniKey key, string comment)
        {
            if (!this.m_items.ContainsKey(key))
            {
                throw new ArgumentException("No item named " + key);
            }
            if (comment == null)
            {
                this.m_itemComments.Remove(key);
            }
            else
            {
                StringSegment segment = new StringSegment(comment);
                this.m_itemComments[key] = segment;
                this.m_content = null;
            }
        }

        public void SetComment(string section, string name, string comment)
        {
            this.SetComment(new MyIniKey(section, name), comment);
        }

        public void SetEndComment(string comment)
        {
            if (comment == null)
            {
                this.m_endComment = new StringSegment();
            }
            else
            {
                this.m_endComment = new StringSegment(comment);
                this.m_content = null;
            }
        }

        public void SetSectionComment(string section, string comment)
        {
            StringSegment key = new StringSegment(section);
            if (!this.m_sections.ContainsKey(key))
            {
                throw new ArgumentException("No section named " + section);
            }
            if (comment == null)
            {
                this.m_sectionComments.Remove(key);
            }
            else
            {
                StringSegment segment2 = new StringSegment(comment);
                this.m_sectionComments[key] = segment2;
                this.m_content = null;
            }
        }

        public override string ToString()
        {
            if (this.m_content == null)
            {
                this.m_content = this.GenerateContent();
            }
            return this.m_content;
        }

        public bool TryParse(string content)
        {
            MyIniParseResult result = new MyIniParseResult();
            return this.TryParseCore(content, null, ref result);
        }

        public bool TryParse(string content, out MyIniParseResult result) => 
            this.TryParse(content, null, out result);

        public bool TryParse(string content, string section)
        {
            MyIniParseResult result = new MyIniParseResult();
            return this.TryParseCore(content, section, ref result);
        }

        public bool TryParse(string content, string section, out MyIniParseResult result)
        {
            result = new MyIniParseResult(new TextPtr(content), null);
            return this.TryParseCore(content, section, ref result);
        }

        private bool TryParseCore(string content, string section, ref MyIniParseResult result)
        {
            content = content ?? "";
            if (!string.Equals(this.m_content, content, StringComparison.Ordinal))
            {
                this.Clear();
                TextPtr ptr = new TextPtr(content);
                if (section != null)
                {
                    int num = FindSection(content, section);
                    if (num == -1)
                    {
                        if (result.IsDefined)
                        {
                            result = new MyIniParseResult(new TextPtr(content), $"Cannot find section "{section}"");
                        }
                        return false;
                    }
                    ptr += num;
                }
                while (!ptr.IsOutOfBounds())
                {
                    if (!this.TryParseSection(ref ptr, ref result, section == null))
                    {
                        if (result.IsDefined && !result.Success)
                        {
                            return false;
                        }
                        break;
                    }
                    if (section != null)
                    {
                        this.m_content = null;
                        return true;
                    }
                }
                this.m_content = content;
            }
            return true;
        }

        private bool TryParseItem(ref StringSegment section, ref TextPtr ptr, ref MyIniParseResult result, bool parseEndContent)
        {
            StringSegment segment;
            TextPtr ptr3;
            TextPtr ptr2 = ptr;
            this.ReadPrefix(ref ptr2, out segment);
            this.m_endComment = segment;
            if (ptr2.StartsWith("---"))
            {
                ptr3 = (ptr2 + 3).SkipWhitespace(false);
                if (ptr3.IsEndOfLine())
                {
                    this.m_endComment = segment;
                    ptr2 = ptr3;
                    ptr3 = new TextPtr(ptr2.Content, ptr2.Content.Length);
                    ptr = ptr3 = ptr3;
                    if (parseEndContent)
                    {
                        ptr2 = ptr2.FindEndOfLine(true);
                        this.m_endContent = new StringSegment(ptr2.Content, ptr2.Index, ptr3.Index - ptr2.Index);
                    }
                    return false;
                }
            }
            ptr2 = ptr2.TrimStart();
            if (!ptr2.IsOutOfBounds() && (ptr2.Char != '['))
            {
                ptr3 = ptr2.FindInLine('=');
                if (ptr3.IsOutOfBounds())
                {
                    if (result.IsDefined)
                    {
                        result = new MyIniParseResult(ptr2, "Expected key=value definition");
                    }
                    return false;
                }
                StringSegment segment2 = new StringSegment(ptr2.Content, ptr2.Index, ptr3.TrimEnd().Index - ptr2.Index);
                string str = MyIniKey.ValidateKey(ref segment2);
                if (str == null)
                {
                    ptr2 = ptr3 + 1;
                    ptr2 = ptr2.TrimStart();
                    ptr3 = ptr2.FindEndOfLine(false);
                    StringSegment segment3 = new StringSegment(ptr2.Content, ptr2.Index, ptr3.TrimEnd().Index - ptr2.Index);
                    if (segment3.Length == 0)
                    {
                        TextPtr ptr4 = ptr3.FindEndOfLine(true);
                        if (ptr4.Char == '|')
                        {
                            TextPtr ptr5 = ptr4;
                            do
                            {
                                ptr4 = ptr5.FindEndOfLine(false);
                                ptr5 = ptr4.FindEndOfLine(true);
                            }
                            while (ptr5.Char == '|');
                            ptr3 = ptr4;
                        }
                        segment3 = new StringSegment(ptr2.Content, ptr2.Index, ptr3.Index - ptr2.Index);
                    }
                    MyIniKey key = new MyIniKey(section, segment2);
                    if (this.m_items.ContainsKey(key))
                    {
                        if (result.IsDefined)
                        {
                            result = new MyIniParseResult(new TextPtr(segment2.Text, segment2.Start), $"Duplicate key {key}");
                        }
                        return false;
                    }
                    this.m_items[key] = segment3;
                    if (!segment.IsEmpty)
                    {
                        this.m_itemComments[key] = segment;
                        this.m_endComment = new StringSegment();
                    }
                    ptr = ptr3.FindEndOfLine(true);
                    return true;
                }
                if (result.IsDefined)
                {
                    result = new MyIniParseResult(ptr2, $"Key {str}");
                }
            }
            return false;
        }

        private bool TryParseSection(ref TextPtr ptr, ref MyIniParseResult result, bool parseEndContent)
        {
            StringSegment segment;
            TextPtr ptr2 = ptr;
            this.ReadPrefix(ref ptr2, out segment);
            this.m_endComment = segment;
            if (ptr2.Char != '[')
            {
                if (result.IsDefined)
                {
                    result = new MyIniParseResult(ptr, "Expected [section] definition");
                }
                return false;
            }
            TextPtr ptr3 = ptr2.FindEndOfLine(false);
            while ((ptr3.Index > ptr2.Index) && (ptr3.Char != ']'))
            {
                ptr3 = TextPtr.op_Decrement(ptr3);
            }
            if (ptr3.Char != ']')
            {
                if (result.IsDefined)
                {
                    result = new MyIniParseResult(ptr, "Expected [section] definition");
                }
                return false;
            }
            ptr2 = TextPtr.op_Increment(ptr2);
            StringSegment segment2 = new StringSegment(ptr2.Content, ptr2.Index, ptr3.Index - ptr2.Index);
            string str = MyIniKey.ValidateSection(ref segment2);
            if (str == null)
            {
                ptr2 = (ptr3 + 1).SkipWhitespace(false);
                if (!ptr2.IsEndOfLine())
                {
                    if (result.IsDefined)
                    {
                        result = new MyIniParseResult(ptr2, "Expected newline");
                    }
                    return false;
                }
                ptr2 = ptr2.FindEndOfLine(true);
                this.AddSection(ref segment2);
                if (!segment.IsEmpty)
                {
                    this.m_sectionComments[segment2] = segment;
                    this.m_endComment = new StringSegment();
                }
                while (this.TryParseItem(ref segment2, ref ptr2, ref result, parseEndContent))
                {
                }
                if (result.IsDefined && !result.Success)
                {
                    return false;
                }
                ptr = ptr2;
                return true;
            }
            if (result.IsDefined)
            {
                result = new MyIniParseResult(ptr2, $"Section {str}");
            }
            return false;
        }

        public string EndComment
        {
            get
            {
                StringSegment endCommentSegment = this.GetEndCommentSegment();
                if (endCommentSegment.IsEmpty)
                {
                    return null;
                }
                return endCommentSegment.ToString();
            }
            set
            {
                if (value == null)
                {
                    this.m_endComment = new StringSegment();
                }
                else
                {
                    this.m_endComment = new StringSegment(value);
                    this.m_content = null;
                }
            }
        }

        public string EndContent
        {
            get => 
                this.m_endContent.ToString();
            set
            {
                this.m_endContent = (value == null) ? new StringSegment() : new StringSegment(value);
                this.m_content = null;
            }
        }

        private StringBuilder TmpContentBuilder
        {
            get
            {
                if (this.m_tmpContentBuilder == null)
                {
                    this.m_tmpContentBuilder = new StringBuilder();
                }
                return this.m_tmpContentBuilder;
            }
        }

        private List<MyIniKey> TmpKeyList
        {
            get
            {
                if (this.m_tmpKeyList == null)
                {
                    this.m_tmpKeyList = new List<MyIniKey>();
                }
                return this.m_tmpKeyList;
            }
        }

        private List<string> TmpStringList
        {
            get
            {
                if (this.m_tmpStringList == null)
                {
                    this.m_tmpStringList = new List<string>();
                }
                return this.m_tmpStringList;
            }
        }

        private StringBuilder TmpValueBuilder
        {
            get
            {
                if (this.m_tmpValueBuilder == null)
                {
                    this.m_tmpValueBuilder = new StringBuilder();
                }
                return this.m_tmpValueBuilder;
            }
        }

        private class MyIniKeyComparer : IEqualityComparer<MyIniKey>
        {
            public static readonly MyIni.MyIniKeyComparer DEFAULT = new MyIni.MyIniKeyComparer();

            public bool Equals(MyIniKey x, MyIniKey y) => 
                x.Equals(y);

            public int GetHashCode(MyIniKey obj) => 
                obj.GetHashCode();
        }
    }
}


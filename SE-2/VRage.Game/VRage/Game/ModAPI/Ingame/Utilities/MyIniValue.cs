namespace VRage.Game.ModAPI.Ingame.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyIniValue
    {
        public static readonly MyIniValue EMPTY;
        private static readonly char[] NEWLINE_CHARS;
        private readonly string m_value;
        public readonly MyIniKey Key;
        public MyIniValue(MyIniKey key, string value)
        {
            if (key.IsEmpty)
            {
                throw new ArgumentException("Configuration value cannot use an empty key", "key");
            }
            this.m_value = value ?? "";
            this.Key = key;
        }

        public bool IsEmpty =>
            (this.m_value == null);
        public bool ToBoolean(bool defaultValue = false)
        {
            bool flag;
            if (!this.TryGetBoolean(out flag))
            {
                return defaultValue;
            }
            return flag;
        }

        public bool TryGetBoolean(out bool value)
        {
            string b = this.m_value;
            if (b == null)
            {
                value = false;
                return false;
            }
            if ((string.Equals("true", b, StringComparison.OrdinalIgnoreCase) || string.Equals("yes", b, StringComparison.OrdinalIgnoreCase)) || (string.Equals("1", b, StringComparison.OrdinalIgnoreCase) || string.Equals("on", b, StringComparison.OrdinalIgnoreCase)))
            {
                value = true;
                return true;
            }
            if ((string.Equals("false", b, StringComparison.OrdinalIgnoreCase) || string.Equals("no", b, StringComparison.OrdinalIgnoreCase)) || (string.Equals("0", b, StringComparison.OrdinalIgnoreCase) || string.Equals("off", b, StringComparison.OrdinalIgnoreCase)))
            {
                value = false;
                return true;
            }
            value = false;
            return false;
        }

        public char ToChar(char defaultValue = '\0')
        {
            char ch;
            if (this.TryGetChar(out ch))
            {
                return ch;
            }
            return defaultValue;
        }

        public bool TryGetChar(out char value)
        {
            if (this.m_value == null)
            {
                value = '\0';
                return false;
            }
            if (this.m_value.Length == 1)
            {
                value = this.m_value[0];
                return true;
            }
            value = '\0';
            return false;
        }

        public sbyte ToSByte(sbyte defaultValue = 0)
        {
            sbyte num;
            if (!this.TryGetSByte(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetSByte(out sbyte value)
        {
            if (this.m_value == null)
            {
                value = 0;
                return false;
            }
            return sbyte.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public byte ToByte(byte defaultValue = 0)
        {
            byte num;
            if (!this.TryGetByte(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetByte(out byte value)
        {
            if (this.m_value == null)
            {
                value = 0;
                return false;
            }
            return byte.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public ushort ToUInt16(ushort defaultValue = 0)
        {
            ushort num;
            if (!this.TryGetUInt16(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetUInt16(out ushort value)
        {
            if (this.m_value == null)
            {
                value = 0;
                return false;
            }
            return ushort.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public short ToInt16(short defaultValue = 0)
        {
            short num;
            if (!this.TryGetInt16(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetInt16(out short value)
        {
            if (this.m_value == null)
            {
                value = 0;
                return false;
            }
            return short.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public uint ToUInt32(uint defaultValue = 0)
        {
            uint num;
            if (!this.TryGetUInt32(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetUInt32(out uint value)
        {
            if (this.m_value == null)
            {
                value = 0;
                return false;
            }
            return uint.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public int ToInt32(int defaultValue = 0)
        {
            int num;
            if (!this.TryGetInt32(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetInt32(out int value)
        {
            if (this.m_value == null)
            {
                value = 0;
                return false;
            }
            return int.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public ulong ToUInt64(ulong defaultValue = 0L)
        {
            ulong num;
            if (!this.TryGetUInt64(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetUInt64(out ulong value)
        {
            if (this.m_value == null)
            {
                value = 0L;
                return false;
            }
            return ulong.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public long ToInt64(long defaultValue = 0L)
        {
            long num;
            if (!this.TryGetInt64(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetInt64(out long value)
        {
            if (this.m_value == null)
            {
                value = 0L;
                return false;
            }
            return long.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public float ToSingle(float defaultValue = 0f)
        {
            float num;
            if (this.TryGetSingle(out num))
            {
                return num;
            }
            return defaultValue;
        }

        public bool TryGetSingle(out float value)
        {
            if (this.m_value == null)
            {
                value = 0f;
                return false;
            }
            return float.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public double ToDouble(double defaultValue = 0.0)
        {
            double num;
            if (!this.TryGetDouble(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetDouble(out double value)
        {
            if (this.m_value == null)
            {
                value = 0.0;
                return false;
            }
            return double.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public decimal ToDecimal([Optional, DecimalConstant(0, 0, (uint) 0, (uint) 0, (uint) 0)] decimal defaultValue)
        {
            decimal num;
            if (!this.TryGetDecimal(out num))
            {
                return defaultValue;
            }
            return num;
        }

        public bool TryGetDecimal(out decimal value)
        {
            if (this.m_value == null)
            {
                value = 0M;
                return false;
            }
            return decimal.TryParse(this.m_value, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        public void GetLines(List<string> lines)
        {
            if (lines != null)
            {
                string str = this.m_value;
                if (!string.IsNullOrEmpty(str))
                {
                    lines.Clear();
                    int startIndex = 0;
                    int num2 = 0;
                    while (num2 < str.Length)
                    {
                        num2 = str.IndexOfAny(NEWLINE_CHARS, startIndex);
                        if (num2 < 0)
                        {
                            lines.Add(str.Substring(startIndex, str.Length - startIndex));
                            return;
                        }
                        lines.Add(str.Substring(startIndex, num2 - startIndex));
                        for (startIndex = num2 + 1; (startIndex < str.Length) && (Array.IndexOf<char>(NEWLINE_CHARS, str[startIndex]) >= 0); startIndex++)
                        {
                        }
                    }
                }
            }
        }

        public override string ToString() => 
            (this.m_value ?? "");

        public string ToString(string defaultValue) => 
            (this.m_value ?? (defaultValue ?? ""));

        public bool TryGetString(out string value)
        {
            value = this.m_value;
            return (value != null);
        }

        public void Write(StringBuilder stringBuilder)
        {
            if (stringBuilder == null)
            {
                throw new ArgumentNullException("stringBuilder");
            }
            stringBuilder.Append(this.m_value ?? "");
        }

        static MyIniValue()
        {
            EMPTY = new MyIniValue();
            NEWLINE_CHARS = new char[] { '\r', '\n' };
        }
    }
}


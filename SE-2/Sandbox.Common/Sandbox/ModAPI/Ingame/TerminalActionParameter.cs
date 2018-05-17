namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [StructLayout(LayoutKind.Sequential)]
    public struct TerminalActionParameter
    {
        public static readonly TerminalActionParameter Empty;
        public readonly System.TypeCode TypeCode;
        public readonly object Value;
        private static Type ToType(System.TypeCode code)
        {
            switch (code)
            {
                case System.TypeCode.Boolean:
                    return typeof(bool);

                case System.TypeCode.Char:
                    return typeof(char);

                case System.TypeCode.SByte:
                    return typeof(sbyte);

                case System.TypeCode.Byte:
                    return typeof(byte);

                case System.TypeCode.Int16:
                    return typeof(short);

                case System.TypeCode.UInt16:
                    return typeof(ushort);

                case System.TypeCode.Int32:
                    return typeof(int);

                case System.TypeCode.UInt32:
                    return typeof(uint);

                case System.TypeCode.Int64:
                    return typeof(long);

                case System.TypeCode.UInt64:
                    return typeof(ulong);

                case System.TypeCode.Single:
                    return typeof(float);

                case System.TypeCode.Double:
                    return typeof(double);

                case System.TypeCode.Decimal:
                    return typeof(decimal);

                case System.TypeCode.DateTime:
                    return typeof(DateTime);

                case System.TypeCode.String:
                    return typeof(string);
            }
            return null;
        }

        public static TerminalActionParameter Deserialize(string serializedValue, System.TypeCode typeCode)
        {
            AssertTypeCodeValidity(typeCode);
            if (ToType(typeCode) == null)
            {
                return Empty;
            }
            return new TerminalActionParameter(typeCode, Convert.ChangeType(serializedValue, typeCode, CultureInfo.InvariantCulture));
        }

        public static TerminalActionParameter Get(object value)
        {
            if (value == null)
            {
                return Empty;
            }
            System.TypeCode typeCode = Type.GetTypeCode(value.GetType());
            AssertTypeCodeValidity(typeCode);
            return new TerminalActionParameter(typeCode, value);
        }

        private static void AssertTypeCodeValidity(System.TypeCode typeCode)
        {
            switch (typeCode)
            {
                case System.TypeCode.Empty:
                case System.TypeCode.Object:
                case System.TypeCode.DBNull:
                    throw new ArgumentException("Only primitive types are allowed for action parameters", "value");
            }
        }

        private TerminalActionParameter(System.TypeCode typeCode, object value)
        {
            this.TypeCode = typeCode;
            this.Value = value;
        }

        public bool IsEmpty =>
            (this.TypeCode == System.TypeCode.Empty);
        public MyObjectBuilder_ToolbarItemActionParameter GetObjectBuilder()
        {
            MyObjectBuilder_ToolbarItemActionParameter parameter = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_ToolbarItemActionParameter>();
            parameter.TypeCode = this.TypeCode;
            parameter.Value = (this.Value == null) ? null : Convert.ToString(this.Value, CultureInfo.InvariantCulture);
            return parameter;
        }

        static TerminalActionParameter()
        {
            Empty = new TerminalActionParameter();
        }
    }
}


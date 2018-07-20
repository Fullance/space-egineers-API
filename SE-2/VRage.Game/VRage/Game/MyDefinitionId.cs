namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.ObjectBuilders;
    using VRage.Utils;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyDefinitionId : IEquatable<MyDefinitionId>
    {
        public static readonly DefinitionIdComparerType Comparer;
        public readonly MyObjectBuilderType TypeId;
        public readonly MyStringHash SubtypeId;
        public static MyDefinitionId FromContent(MyObjectBuilder_Base content) => 
            new MyDefinitionId(content.TypeId, content.SubtypeId);

        public static MyDefinitionId Parse(string id)
        {
            MyDefinitionId id2;
            if (!TryParse(id, out id2))
            {
                throw new ArgumentException("The provided type does not conform to a definition ID.", "id");
            }
            return id2;
        }

        public static bool TryParse(string id, out MyDefinitionId definitionId)
        {
            MyObjectBuilderType type;
            if (string.IsNullOrEmpty(id))
            {
                definitionId = new MyDefinitionId();
                return false;
            }
            int index = id.IndexOf('/');
            if (index == -1)
            {
                definitionId = new MyDefinitionId();
                return false;
            }
            if (MyObjectBuilderType.TryParse(id.Substring(0, index).Trim(), out type))
            {
                string subtypeName = id.Substring(index + 1).Trim();
                if (subtypeName == "(null)")
                {
                    subtypeName = null;
                }
                definitionId = new MyDefinitionId(type, subtypeName);
                return true;
            }
            definitionId = new MyDefinitionId();
            return false;
        }

        public static bool TryParse(string type, string subtype, out MyDefinitionId definitionId)
        {
            MyObjectBuilderType type2;
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(subtype))
            {
                definitionId = new MyDefinitionId();
                return false;
            }
            if (MyObjectBuilderType.TryParse(type, out type2))
            {
                definitionId = new MyDefinitionId(type2, subtype);
                return true;
            }
            definitionId = new MyDefinitionId();
            return false;
        }

        public string SubtypeName =>
            this.SubtypeId.ToString();
        public MyDefinitionId(MyObjectBuilderType type) : this(type, MyStringHash.GetOrCompute(null))
        {
        }

        public MyDefinitionId(MyObjectBuilderType type, string subtypeName) : this(type, MyStringHash.GetOrCompute(subtypeName))
        {
        }

        public MyDefinitionId(MyObjectBuilderType type, MyStringHash subtypeId)
        {
            this.TypeId = type;
            this.SubtypeId = subtypeId;
        }

        public MyDefinitionId(MyRuntimeObjectBuilderId type, MyStringHash subtypeId)
        {
            this.TypeId = (MyObjectBuilderType) type;
            this.SubtypeId = subtypeId;
        }

        public override int GetHashCode() => 
            ((this.TypeId.GetHashCode() << 0x10) ^ this.SubtypeId.GetHashCode());

        public long GetHashCodeLong() => 
            ((this.TypeId.GetHashCode() << 0x20) ^ this.SubtypeId.GetHashCode());

        public override bool Equals(object obj) => 
            ((obj is MyDefinitionId) && this.Equals((MyDefinitionId) obj));

        public override string ToString()
        {
            string str = !this.TypeId.IsNull ? this.TypeId.ToString() : "(null)";
            string str2 = !string.IsNullOrEmpty(this.SubtypeName) ? this.SubtypeName : "(null)";
            return $"{str}/{str2}";
        }

        public bool Equals(MyDefinitionId other) => 
            ((this.TypeId == other.TypeId) && (this.SubtypeId == other.SubtypeId));

        public static bool operator ==(MyDefinitionId l, MyDefinitionId r) => 
            l.Equals(r);

        public static bool operator !=(MyDefinitionId l, MyDefinitionId r) => 
            !l.Equals(r);

        public static implicit operator MyDefinitionId(SerializableDefinitionId v) => 
            new MyDefinitionId(v.TypeId, v.SubtypeName);

        public static implicit operator SerializableDefinitionId(MyDefinitionId v) => 
            new SerializableDefinitionId(v.TypeId, v.SubtypeName);

        static MyDefinitionId()
        {
            Comparer = new DefinitionIdComparerType();
        }
        public class DefinitionIdComparerType : IEqualityComparer<MyDefinitionId>
        {
            public bool Equals(MyDefinitionId x, MyDefinitionId y) => 
                ((x.TypeId == y.TypeId) && (x.SubtypeId == y.SubtypeId));

            public int GetHashCode(MyDefinitionId obj) => 
                obj.GetHashCode();
        }
    }
}


namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Text;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_AnimationSMCondition : MyObjectBuilder_Base
    {
        [ProtoMember(0x21), XmlAttribute("Op")]
        public MyOperationType Operation;
        [XmlAttribute("Lhs"), ProtoMember(0x1c)]
        public string ValueLeft;
        [ProtoMember(40), XmlAttribute("Rhs")]
        public string ValueRight;

        public override string ToString()
        {
            if (this.Operation == MyOperationType.AlwaysTrue)
            {
                return "true";
            }
            if (this.Operation == MyOperationType.AlwaysFalse)
            {
                return "false";
            }
            StringBuilder builder = new StringBuilder(0x80);
            builder.Append(this.ValueLeft);
            builder.Append(" ");
            switch (this.Operation)
            {
                case MyOperationType.NotEqual:
                    builder.Append("!=");
                    break;

                case MyOperationType.Less:
                    builder.Append("<");
                    break;

                case MyOperationType.LessOrEqual:
                    builder.Append("<=");
                    break;

                case MyOperationType.Equal:
                    builder.Append("==");
                    break;

                case MyOperationType.GreaterOrEqual:
                    builder.Append(">=");
                    break;

                case MyOperationType.Greater:
                    builder.Append(">");
                    break;

                default:
                    builder.Append("???");
                    break;
            }
            builder.Append(" ");
            builder.Append(this.ValueRight);
            return builder.ToString();
        }

        public enum MyOperationType
        {
            AlwaysFalse,
            AlwaysTrue,
            NotEqual,
            Less,
            LessOrEqual,
            Equal,
            GreaterOrEqual,
            Greater
        }
    }
}


namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Text;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_AnimationSMConditionsConjunction : MyObjectBuilder_Base
    {
        [ProtoMember(0x5e), XmlElement("Condition")]
        public MyObjectBuilder_AnimationSMCondition[] Conditions;

        public MyObjectBuilder_AnimationSMConditionsConjunction DeepCopy()
        {
            MyObjectBuilder_AnimationSMConditionsConjunction conjunction = new MyObjectBuilder_AnimationSMConditionsConjunction();
            if (this.Conditions != null)
            {
                conjunction.Conditions = new MyObjectBuilder_AnimationSMCondition[this.Conditions.Length];
                for (int i = 0; i < this.Conditions.Length; i++)
                {
                    conjunction.Conditions[i] = new MyObjectBuilder_AnimationSMCondition { 
                        Operation = this.Conditions[i].Operation,
                        ValueLeft = this.Conditions[i].ValueLeft,
                        ValueRight = this.Conditions[i].ValueRight
                    };
                }
                return conjunction;
            }
            conjunction.Conditions = null;
            return conjunction;
        }

        public override string ToString()
        {
            if ((this.Conditions == null) || (this.Conditions.Length == 0))
            {
                return "[no content, false]";
            }
            bool flag = true;
            StringBuilder builder = new StringBuilder(0x200);
            builder.Append("[");
            foreach (MyObjectBuilder_AnimationSMCondition condition in this.Conditions)
            {
                if (!flag)
                {
                    builder.Append(" AND ");
                }
                builder.Append(condition.ToString());
                flag = false;
            }
            builder.Append("]");
            return builder.ToString();
        }
    }
}


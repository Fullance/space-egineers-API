namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), XmlType("Condition"), MyObjectBuilderDefinition((Type) null, null)]
    public class Condition : ConditionBase
    {
        public StatLogicOperator Operator;
        [XmlArrayItem("Term", Type=typeof(MyAbstractXmlSerializer<ConditionBase>))]
        public ConditionBase[] Terms;

        public override bool Eval()
        {
            if (this.Terms == null)
            {
                return false;
            }
            bool flag = this.Terms[0].Eval();
            if (this.Operator == StatLogicOperator.Not)
            {
                return !flag;
            }
            for (int i = 1; i < this.Terms.Length; i++)
            {
                ConditionBase base2 = this.Terms[i];
                switch (this.Operator)
                {
                    case StatLogicOperator.And:
                        flag &= base2.Eval();
                        break;

                    case StatLogicOperator.Or:
                        flag |= base2.Eval();
                        break;
                }
            }
            return flag;
        }
    }
}


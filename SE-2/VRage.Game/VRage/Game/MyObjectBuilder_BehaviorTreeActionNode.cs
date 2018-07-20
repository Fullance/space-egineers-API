namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_BehaviorTreeActionNode : MyObjectBuilder_BehaviorTreeNode
    {
        [ProtoMember(0x62)]
        public string ActionName;
        [ProtoMember(0x65), XmlArrayItem("Parameter", Type=typeof(MyAbstractXmlSerializer<TypeValue>))]
        public TypeValue[] Parameters;

        [XmlType("BoolType"), ProtoContract]
        public class BoolType : MyObjectBuilder_BehaviorTreeActionNode.TypeValue
        {
            [ProtoMember(0x4b), XmlAttribute]
            public bool BoolValue;

            public override object GetValue() => 
                this.BoolValue;
        }

        [XmlType("FloatType"), ProtoContract]
        public class FloatType : MyObjectBuilder_BehaviorTreeActionNode.TypeValue
        {
            [ProtoMember(0x3d), XmlAttribute]
            public float FloatValue;

            public override object GetValue() => 
                this.FloatValue;
        }

        [XmlType("IntType"), ProtoContract]
        public class IntType : MyObjectBuilder_BehaviorTreeActionNode.TypeValue
        {
            [XmlAttribute, ProtoMember(0x22)]
            public int IntValue;

            public override object GetValue() => 
                this.IntValue;
        }

        [ProtoContract, XmlType("MemType")]
        public class MemType : MyObjectBuilder_BehaviorTreeActionNode.TypeValue
        {
            [ProtoMember(0x59), XmlAttribute]
            public string MemName;

            public override object GetValue() => 
                this.MemName;
        }

        [XmlType("StringType"), ProtoContract]
        public class StringType : MyObjectBuilder_BehaviorTreeActionNode.TypeValue
        {
            [ProtoMember(0x2f), XmlAttribute]
            public string StringValue;

            public override object GetValue() => 
                this.StringValue;
        }

        [XmlType("TypeValue"), ProtoContract]
        public abstract class TypeValue
        {
            protected TypeValue()
            {
            }

            public abstract object GetValue();
        }
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlType("Operation")]
    public abstract class MyObjectBuilder_WorldGeneratorOperation : MyObjectBuilder_Base
    {
        [ProtoMember(0xc5)]
        public string FactionTag;

        protected MyObjectBuilder_WorldGeneratorOperation()
        {
        }
    }
}


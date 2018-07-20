namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ComponentContainer : MyObjectBuilder_Base
    {
        [ProtoMember(0x19)]
        public List<ComponentData> Components = new List<ComponentData>();

        [ProtoContract]
        public class ComponentData
        {
            [ProtoMember(0x13), XmlElement(Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ComponentBase>)), DynamicObjectBuilder(false)]
            public MyObjectBuilder_ComponentBase Component;
            [ProtoMember(0x10)]
            public string TypeId;
        }
    }
}


namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game.ObjectBuilders.ComponentSystem;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_HierarchyComponentBase : MyObjectBuilder_ComponentBase
    {
        [ProtoMember(15, AsReference=true), DynamicItem(typeof(MyObjectBuilderDynamicSerializer), true), XmlArrayItem("MyObjectBuilder_EntityBase", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_EntityBase>))]
        public List<MyObjectBuilder_EntityBase> Children = new List<MyObjectBuilder_EntityBase>();
    }
}


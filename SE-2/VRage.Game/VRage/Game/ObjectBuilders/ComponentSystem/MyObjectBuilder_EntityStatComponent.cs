namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game.ObjectBuilders;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_EntityStatComponent : MyObjectBuilder_ComponentBase
    {
        [ProtoMember(0x10), Serialize(MyObjectFlags.DefaultZero)]
        public string[] ScriptNames;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(12)]
        public MyObjectBuilder_EntityStat[] Stats;
    }
}


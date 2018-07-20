namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_UseObjectsComponentDefinition : MyObjectBuilder_ComponentDefinitionBase
    {
        [ProtoMember(13)]
        public bool LoadFromModel;
        [ProtoMember(0x11), DefaultValue((string) null)]
        public string UseObjectFromModelBBox;
    }
}


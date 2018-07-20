namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public abstract class MyObjectBuilder_ToolbarItemDefinition : MyObjectBuilder_ToolbarItem
    {
        [ProtoMember(11)]
        public SerializableDefinitionId DefinitionId;

        protected MyObjectBuilder_ToolbarItemDefinition()
        {
        }
    }
}


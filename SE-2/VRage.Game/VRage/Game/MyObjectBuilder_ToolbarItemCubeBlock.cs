namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ToolbarItemCubeBlock : MyObjectBuilder_ToolbarItemDefinition
    {
        public bool ShouldSerializedefId() => 
            false;

        public SerializableDefinitionId defId
        {
            get => 
                base.DefinitionId;
            set
            {
                base.DefinitionId = value;
            }
        }
    }
}


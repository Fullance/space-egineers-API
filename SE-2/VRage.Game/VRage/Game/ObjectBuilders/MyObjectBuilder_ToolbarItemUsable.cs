namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, "MyObjectBuilder_ToolbarItemConsumable"), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ToolbarItemUsable : MyObjectBuilder_ToolbarItemDefinition
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


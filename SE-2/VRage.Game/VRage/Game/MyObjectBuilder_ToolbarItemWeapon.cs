namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_ToolbarItemWeapon : MyObjectBuilder_ToolbarItemDefinition
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


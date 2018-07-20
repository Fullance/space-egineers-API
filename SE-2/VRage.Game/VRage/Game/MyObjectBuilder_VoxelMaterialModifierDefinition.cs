namespace VRage.Game
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_VoxelMaterialModifierDefinition : MyObjectBuilder_DefinitionBase
    {
        [XmlArrayItem("Option")]
        public MyVoxelMapModifierOption[] Options;
    }
}


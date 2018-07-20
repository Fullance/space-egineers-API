namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_MainMenuInventorySceneDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x11, IsRequired=false)]
        public string SceneDirectory;
    }
}


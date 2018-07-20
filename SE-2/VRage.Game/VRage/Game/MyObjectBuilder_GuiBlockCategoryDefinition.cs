namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GuiBlockCategoryDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(30)]
        public bool IsAnimationCategory;
        [ProtoMember(0x18)]
        public bool IsBlockCategory = true;
        [ProtoMember(0x15)]
        public bool IsShipCategory;
        [ProtoMember(0x21)]
        public bool IsToolCategory;
        [ProtoMember(0x12)]
        public string[] ItemIds;
        [ProtoMember(15)]
        public string Name;
        [ProtoMember(0x1b)]
        public bool SearchBlocks = true;
        [ProtoMember(0x24)]
        public bool ShowAnimations;
        [ProtoMember(0x27)]
        public bool ShowInCreative = true;
    }
}


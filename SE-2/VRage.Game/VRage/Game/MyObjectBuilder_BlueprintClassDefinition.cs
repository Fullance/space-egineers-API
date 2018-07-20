namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_BlueprintClassDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(13), ModdableContentFile("dds")]
        public string HighlightIcon;
        [ModdableContentFile("dds"), ProtoMember(0x11)]
        public string InputConstraintIcon;
        [ProtoMember(0x15), ModdableContentFile("dds")]
        public string OutputConstraintIcon;
        [ProtoMember(0x19), DefaultValue((string) null)]
        public string ProgressBarSoundCue;
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_BlueprintDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x1f)]
        public float BaseProductionTimeInSeconds = 1f;
        [ProtoMember(13), XmlArrayItem("Item")]
        public BlueprintItem[] Prerequisites;
        [ProtoMember(0x22), DefaultValue((string) null)]
        public string ProgressBarSoundCue;
        [ProtoMember(20)]
        public BlueprintItem Result;
        [ProtoMember(0x17), XmlArrayItem("Item")]
        public BlueprintItem[] Results;
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_AnimationDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x33)]
        public bool AllowInCockpit = true;
        [ProtoMember(0x36)]
        public bool AllowWithWeapon;
        [ModdableContentFile("mwm"), ProtoMember(0x25)]
        public string AnimationModel;
        [ModdableContentFile("mwm"), ProtoMember(0x29)]
        public string AnimationModelFPS;
        [ProtoMember(0x42), DefaultValue((string) null), XmlArrayItem("AnimationSet")]
        public AnimationSet[] AnimationSets;
        [ProtoMember(0x2d)]
        public int ClipIndex;
        [ProtoMember(0x30)]
        public string InfluenceArea;
        [ProtoMember(0x3f)]
        public SerializableDefinitionId LeftHandItem;
        [ProtoMember(60)]
        public bool Loop;
        [ProtoMember(0x39)]
        public string SupportedSkeletons = "Humanoid";
    }
}


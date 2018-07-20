namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.Data.Audio;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_AudioEffectDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x2a), DefaultValue(0)]
        public int OutputSound;
        [ProtoMember(0x27), XmlArrayItem("Sound")]
        public List<SoundList> Sounds;

        [ProtoContract]
        public class SoundEffect
        {
            [ProtoMember(0x1a)]
            public float Duration;
            [DefaultValue(4), ProtoMember(0x1c)]
            public MyAudioEffect.FilterType Filter = MyAudioEffect.FilterType.None;
            [ProtoMember(30), DefaultValue((float) 1f)]
            public float Frequency = 1f;
            [ProtoMember(0x22), DefaultValue((float) 1f)]
            public float Q = 1f;
            [DefaultValue(false), ProtoMember(0x20)]
            public bool StopAfter;
            [ProtoMember(0x18)]
            public string VolumeCurve;
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct SoundList
        {
            [ProtoMember(0x12)]
            public List<MyObjectBuilder_AudioEffectDefinition.SoundEffect> SoundEffects;
        }
    }
}


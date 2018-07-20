namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_ShipSoundsDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x27)]
        public bool AllowLargeGrid = true;
        [ProtoMember(0x24)]
        public bool AllowSmallGrid = true;
        [ProtoMember(0x2a)]
        public float EnginePitchRangeInSemitones = 4f;
        [ProtoMember(0x30)]
        public float EngineTimeToTurnOff = 3f;
        [ProtoMember(0x2d)]
        public float EngineTimeToTurnOn = 4f;
        [XmlArrayItem("EngineVolume"), ProtoMember(0x57)]
        public List<ShipSoundVolumePair> EngineVolumes;
        [ProtoMember(0x21)]
        public float MinWeight = 3000f;
        [ProtoMember(90), XmlArrayItem("Sound")]
        public List<ShipSound> Sounds;
        [ProtoMember(0x36)]
        public float SpeedDownSoundChangeVolumeTo = 1f;
        [ProtoMember(0x39)]
        public float SpeedUpDownChangeSpeed = 0.2f;
        [ProtoMember(0x33)]
        public float SpeedUpSoundChangeVolumeTo = 1f;
        [ProtoMember(0x4e)]
        public float ThrusterCompositionChangeSpeed = 0.025f;
        [ProtoMember(0x4b)]
        public float ThrusterCompositionMinVolume = 0.4f;
        [ProtoMember(0x48)]
        public float ThrusterPitchRangeInSemitones = 4f;
        [ProtoMember(0x54), XmlArrayItem("ThrusterVolume")]
        public List<ShipSoundVolumePair> ThrusterVolumes;
        [ProtoMember(0x42)]
        public float WheelsFullSpeed = 32f;
        [ProtoMember(0x45)]
        public float WheelsGroundMinVolume = 0.5f;
        [ProtoMember(0x3f)]
        public float WheelsLowerThrusterVolumeBy = 0.33f;
        [ProtoMember(60)]
        public float WheelsPitchRangeInSemitones = 4f;
        [ProtoMember(0x51), XmlArrayItem("WheelsVolume")]
        public List<ShipSoundVolumePair> WheelsVolumes;
    }
}


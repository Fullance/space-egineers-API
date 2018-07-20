namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class ShipSound
    {
        [XmlAttribute("SoundName"), ProtoMember(100)]
        public string SoundName = "";
        [XmlAttribute("Type"), ProtoMember(0x61)]
        public ShipSystemSoundsEnum SoundType = ShipSystemSoundsEnum.MainLoopMedium;
    }
}


namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRageMath;

    [ProtoContract]
    public class MySerializablePlanetEnvironmentalSoundRule
    {
        [ProtoMember(0x1a0)]
        public string EnvironmentSound;
        [ProtoMember(0x197)]
        public SerializableRange Height = new SerializableRange(0f, 1f);
        [ProtoMember(410)]
        public SymmetricSerializableRange Latitude = new SymmetricSerializableRange(-90f, 90f, true);
        [ProtoMember(0x19d)]
        public SerializableRange SunAngleFromZenith = new SerializableRange(0f, 180f);
    }
}


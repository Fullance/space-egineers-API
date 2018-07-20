namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyPlanetAnimalSpawnInfo
    {
        [XmlArrayItem("Animal")]
        public MyPlanetAnimal[] Animals;
        [ProtoMember(0x129)]
        public int KillDelay = 0x1d4c0;
        [ProtoMember(0x120)]
        public int SpawnDelayMax = 0xea60;
        [ProtoMember(0x11d)]
        public int SpawnDelayMin = 0x7530;
        [ProtoMember(0x126)]
        public float SpawnDistMax = 140f;
        [ProtoMember(0x123)]
        public float SpawnDistMin = 10f;
        [ProtoMember(0x12f)]
        public int WaveCountMax = 5;
        [ProtoMember(300)]
        public int WaveCountMin = 1;
    }
}


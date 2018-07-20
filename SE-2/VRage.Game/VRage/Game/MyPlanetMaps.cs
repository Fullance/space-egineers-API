namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyPlanetMaps
    {
        [XmlAttribute, ProtoMember(0x178)]
        public bool Material;
        [ProtoMember(380), XmlAttribute]
        public bool Ores;
        [XmlAttribute, ProtoMember(0x180)]
        public bool Biome;
        [XmlAttribute, ProtoMember(0x184)]
        public bool Occlusion;
        public MyPlanetMapTypeSet ToSet()
        {
            MyPlanetMapTypeSet set = 0;
            if (this.Material)
            {
                set |= MyPlanetMapTypeSet.Material;
            }
            if (this.Ores)
            {
                set |= MyPlanetMapTypeSet.Ore;
            }
            if (this.Biome)
            {
                set |= MyPlanetMapTypeSet.Biome;
            }
            return set;
        }
    }
}


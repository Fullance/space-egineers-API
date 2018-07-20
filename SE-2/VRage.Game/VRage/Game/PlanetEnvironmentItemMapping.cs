namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct PlanetEnvironmentItemMapping
    {
        [XmlArrayItem("Material"), ProtoMember(0x1e5)]
        public string[] Materials;
        [XmlArrayItem("Biome"), ProtoMember(0x1e9)]
        public int[] Biomes;
        [XmlArrayItem("Item"), ProtoMember(0x1ed)]
        public MyPlanetEnvironmentItemDef[] Items;
        [ProtoMember(0x1f1)]
        public MyPlanetSurfaceRule Rule;
    }
}


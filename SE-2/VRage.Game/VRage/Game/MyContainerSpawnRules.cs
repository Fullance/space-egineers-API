namespace VRage.Game
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class MyContainerSpawnRules
    {
        [ProtoMember(0x15, IsRequired=false)]
        public bool CanBeCompetetive = true;
        [ProtoMember(0x12, IsRequired=false)]
        public bool CanBePersonal = true;
        [ProtoMember(12, IsRequired=false)]
        public bool CanSpawnInAtmosphere = true;
        [ProtoMember(9, IsRequired=false)]
        public bool CanSpawnInSpace = true;
        [ProtoMember(15, IsRequired=false)]
        public bool CanSpawnOnMoon = true;
    }
}


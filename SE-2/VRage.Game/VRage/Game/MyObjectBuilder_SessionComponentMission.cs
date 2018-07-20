namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using VRage.Serialization;

    [ProtoContract]
    public class MyObjectBuilder_SessionComponentMission
    {
        [ProtoMember(0x16)]
        public SerializableDictionary<pair, MyObjectBuilder_MissionTriggers> Triggers = new SerializableDictionary<pair, MyObjectBuilder_MissionTriggers>();

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct pair
        {
            public ulong stm;
            public int ser;
            public pair(ulong p1, int p2)
            {
                this.stm = p1;
                this.ser = p2;
            }
        }
    }
}


namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class PlayerContainerData
    {
        [ProtoMember(60)]
        public bool Active;
        [ProtoMember(0x3f)]
        public bool Competetive;
        [ProtoMember(0x42)]
        public long ContainerId;
        [ProtoMember(0x36)]
        public long PlayerId;
        [ProtoMember(0x39)]
        public int Timer;

        public PlayerContainerData()
        {
        }

        public PlayerContainerData(long player, int timer, bool active, bool competetive, long container)
        {
            this.PlayerId = player;
            this.Timer = timer;
            this.Active = active;
            this.Competetive = competetive;
            this.ContainerId = container;
        }
    }
}


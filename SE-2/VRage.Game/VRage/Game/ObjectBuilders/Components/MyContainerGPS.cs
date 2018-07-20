namespace VRage.Game.ObjectBuilders.Components
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class MyContainerGPS
    {
        [ProtoMember(0x11)]
        public string GPSName;
        [ProtoMember(14)]
        public int TimeLeft;

        public MyContainerGPS()
        {
        }

        public MyContainerGPS(int time, string name)
        {
            this.TimeLeft = time;
            this.GPSName = name;
        }
    }
}


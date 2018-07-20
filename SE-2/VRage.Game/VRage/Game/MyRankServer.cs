namespace VRage.Game
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public class MyRankServer
    {
        [XmlAttribute]
        public string Address { get; set; }

        [XmlAttribute]
        public int Rank { get; set; }
    }
}


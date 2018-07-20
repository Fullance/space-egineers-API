namespace VRage.Game.News
{
    using System;
    using System.Xml.Serialization;

    public class MyNewsEntry
    {
        [XmlAttribute(AttributeName="date")]
        public string Date;
        [XmlAttribute(AttributeName="dev")]
        public bool Dev;
        [XmlAttribute(AttributeName="public")]
        public bool Public = true;
        [XmlText]
        public string Text;
        [XmlAttribute(AttributeName="title")]
        public string Title;
        [XmlAttribute(AttributeName="version")]
        public string Version;
    }
}


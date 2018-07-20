namespace VRage.Game.News
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName="News")]
    public class MyNews
    {
        [XmlElement("Entry")]
        public List<MyNewsEntry> Entry;
    }
}


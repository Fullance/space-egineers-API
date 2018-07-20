namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_AIComponent : MyObjectBuilder_SessionComponent
    {
        [ProtoMember(0x19)]
        public List<BotData> BotBrains = new List<BotData>();

        public bool ShouldSerializeBotBrains() => 
            ((this.BotBrains != null) && (this.BotBrains.Count > 0));

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct BotData
        {
            [ProtoMember(0x11)]
            public int PlayerHandle;
            [XmlElement(Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_Bot>)), ProtoMember(20)]
            public MyObjectBuilder_Bot BotBrain;
        }
    }
}


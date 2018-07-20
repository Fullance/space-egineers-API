namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_BlockGroup : MyObjectBuilder_Base
    {
        [ProtoMember(0x10)]
        public List<Vector3I> Blocks = new List<Vector3I>();
        [ProtoMember(13)]
        public string Name;
    }
}


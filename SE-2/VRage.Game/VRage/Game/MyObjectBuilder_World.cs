namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_World : MyObjectBuilder_Base
    {
        [ProtoMember(14)]
        public MyObjectBuilder_Checkpoint Checkpoint;
        public List<BoundingBoxD> Clusters;
        [ProtoMember(0x11)]
        public MyObjectBuilder_Sector Sector;
        [ProtoMember(20)]
        public SerializableDictionary<string, byte[]> VoxelMaps;
    }
}


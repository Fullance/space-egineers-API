namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_WorldGenerator : MyObjectBuilder_SessionComponent
    {
        [ProtoMember(50)]
        public HashSet<EmptyArea> DeletedAreas = new HashSet<EmptyArea>();
        [ProtoMember(0x35)]
        public HashSet<MyObjectSeedParams> ExistingObjectsSeeds = new HashSet<MyObjectSeedParams>();
        [ProtoMember(0x2f)]
        public HashSet<EmptyArea> MarkedAreas = new HashSet<EmptyArea>();
    }
}


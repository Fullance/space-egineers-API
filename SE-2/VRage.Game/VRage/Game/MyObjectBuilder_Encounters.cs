namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_Encounters : MyObjectBuilder_SessionComponent
    {
        [ProtoMember(0x43)]
        public SerializableDictionary<MyEncounterId, Vector3D> MovedOnlyEncounters;
        [ProtoMember(0x40)]
        public HashSet<MyEncounterId> SavedEcounters = new HashSet<MyEncounterId>();
    }
}


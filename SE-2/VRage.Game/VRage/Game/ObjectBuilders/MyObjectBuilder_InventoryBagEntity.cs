namespace VRage.Game.ObjectBuilders
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_InventoryBagEntity : MyObjectBuilder_EntityBase
    {
        public SerializableVector3 AngularVelocity;
        public SerializableVector3 LinearVelocity;
        public float Mass = 5f;
        public long OwnerIdentityId;
    }
}


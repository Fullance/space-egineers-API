namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Serialization;
    using VRage.Utils;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_PhysicalGunObject : MyObjectBuilder_PhysicalObject
    {
        [Serialize(MyObjectFlags.Dynamic | MyObjectFlags.DefaultZero, DynamicSerializerType=typeof(MyObjectBuilderDynamicSerializer)), ProtoMember(14), XmlElement("GunEntity", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_EntityBase>))]
        public MyObjectBuilder_EntityBase GunEntity;

        public MyObjectBuilder_PhysicalGunObject() : this(null)
        {
        }

        public MyObjectBuilder_PhysicalGunObject(MyObjectBuilder_EntityBase gunEntity)
        {
            this.GunEntity = gunEntity;
        }

        public override bool CanStack(MyObjectBuilderType type, MyStringHash subtypeId, MyItemFlags flags) => 
            false;
    }
}


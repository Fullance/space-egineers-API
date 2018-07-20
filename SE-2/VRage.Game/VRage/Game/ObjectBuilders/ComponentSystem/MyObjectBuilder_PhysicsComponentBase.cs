namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public abstract class MyObjectBuilder_PhysicsComponentBase : MyObjectBuilder_ComponentBase
    {
        public SerializableVector3 AngularVelocity;
        public SerializableVector3 LinearVelocity;

        protected MyObjectBuilder_PhysicsComponentBase()
        {
        }
    }
}


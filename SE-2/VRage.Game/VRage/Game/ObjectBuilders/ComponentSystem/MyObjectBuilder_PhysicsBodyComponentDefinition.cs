namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_PhysicsBodyComponentDefinition : MyObjectBuilder_PhysicsComponentDefinitionBase
    {
        [ProtoMember(11)]
        public bool CreateFromCollisionObject;
    }
}


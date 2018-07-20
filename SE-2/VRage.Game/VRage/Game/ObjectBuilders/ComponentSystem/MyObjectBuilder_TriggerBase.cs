namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((System.Type) null, null)]
    public class MyObjectBuilder_TriggerBase : MyObjectBuilder_ComponentBase
    {
        [ProtoMember(0x10)]
        public SerializableBoundingBoxD AABB;
        [ProtoMember(0x13)]
        public SerializableBoundingSphereD BoundingSphere;
        [ProtoMember(0x16)]
        public SerializableVector3D Offset = Vector3D.Zero;
        [ProtoMember(13)]
        public int Type;
    }
}


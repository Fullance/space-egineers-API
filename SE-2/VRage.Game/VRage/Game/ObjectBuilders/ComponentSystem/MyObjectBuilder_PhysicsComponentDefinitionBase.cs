namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.Game.Components;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_PhysicsComponentDefinitionBase : MyObjectBuilder_ComponentDefinitionBase
    {
        [ProtoMember(0x29), DefaultValue((string) null)]
        public float? AngularDamping = null;
        [DefaultValue((string) null), ProtoMember(0x23)]
        public string CollisionLayer;
        [ProtoMember(0x2c)]
        public bool ForceActivate;
        [DefaultValue((string) null), ProtoMember(0x26)]
        public float? LinearDamping = null;
        [DefaultValue(0), ProtoMember(0x1d)]
        public MyMassPropertiesComputationType MassPropertiesComputation;
        [DefaultValue(0), ProtoMember(0x20)]
        public RigidBodyFlag RigidBodyFlags;
        [ProtoMember(50)]
        public bool Serialize;
        [ProtoMember(0x2f)]
        public MyUpdateFlags UpdateFlags;

        public enum MyMassPropertiesComputationType
        {
            None,
            Box,
            Sphere,
            Capsule,
            Cylinder
        }

        [Flags]
        public enum MyUpdateFlags
        {
            Gravity = 1
        }
    }
}


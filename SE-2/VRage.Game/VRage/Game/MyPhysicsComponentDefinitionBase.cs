namespace VRage.Game
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game.Components;
    using VRage.Game.Definitions;
    using VRage.Game.ObjectBuilders.ComponentSystem;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyDefinitionType(typeof(MyObjectBuilder_PhysicsComponentDefinitionBase), (Type) null)]
    public class MyPhysicsComponentDefinitionBase : MyComponentDefinitionBase
    {
        public float? AngularDamping;
        public string CollisionLayer;
        public bool ForceActivate;
        public float? LinearDamping;
        public MyObjectBuilder_PhysicsComponentDefinitionBase.MyMassPropertiesComputationType MassPropertiesComputation;
        public RigidBodyFlag RigidBodyFlags;
        public bool Serialize;
        public MyObjectBuilder_PhysicsComponentDefinitionBase.MyUpdateFlags UpdateFlags;

        public override MyObjectBuilder_DefinitionBase GetObjectBuilder()
        {
            MyObjectBuilder_PhysicsComponentDefinitionBase objectBuilder = base.GetObjectBuilder() as MyObjectBuilder_PhysicsComponentDefinitionBase;
            objectBuilder.MassPropertiesComputation = this.MassPropertiesComputation;
            objectBuilder.RigidBodyFlags = this.RigidBodyFlags;
            objectBuilder.CollisionLayer = this.CollisionLayer;
            objectBuilder.LinearDamping = this.LinearDamping;
            objectBuilder.AngularDamping = this.AngularDamping;
            objectBuilder.ForceActivate = this.ForceActivate;
            objectBuilder.UpdateFlags = this.UpdateFlags;
            objectBuilder.Serialize = this.Serialize;
            return objectBuilder;
        }

        protected override void Init(MyObjectBuilder_DefinitionBase builder)
        {
            base.Init(builder);
            MyObjectBuilder_PhysicsComponentDefinitionBase base2 = builder as MyObjectBuilder_PhysicsComponentDefinitionBase;
            this.MassPropertiesComputation = base2.MassPropertiesComputation;
            this.RigidBodyFlags = base2.RigidBodyFlags;
            this.CollisionLayer = base2.CollisionLayer;
            this.LinearDamping = base2.LinearDamping;
            this.AngularDamping = base2.AngularDamping;
            this.ForceActivate = base2.ForceActivate;
            this.UpdateFlags = base2.UpdateFlags;
            this.Serialize = base2.Serialize;
        }
    }
}


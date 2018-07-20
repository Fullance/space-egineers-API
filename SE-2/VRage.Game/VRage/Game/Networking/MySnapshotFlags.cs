namespace VRage.Game.Networking
{
    using System;

    public class MySnapshotFlags
    {
        public bool ApplyPhysicsAngular;
        public bool ApplyPhysicsLinear;
        public bool ApplyPhysicsLocal;
        public bool ApplyPosition;
        public bool ApplyRotation;
        public bool InheritRotation = true;

        public void Init(bool state)
        {
            this.ApplyPosition = state;
            this.ApplyRotation = state;
            this.ApplyPhysicsAngular = state;
            this.ApplyPhysicsLinear = state;
        }

        public void Init(MySnapshotFlags flags)
        {
            this.ApplyPosition = flags.ApplyPosition;
            this.ApplyRotation = flags.ApplyRotation;
            this.ApplyPhysicsAngular = flags.ApplyPhysicsAngular;
            this.ApplyPhysicsLinear = flags.ApplyPhysicsLinear;
            this.ApplyPhysicsLocal = flags.ApplyPhysicsLocal;
            this.InheritRotation = flags.InheritRotation;
        }
    }
}


namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyShipVelocities
    {
        public readonly Vector3D LinearVelocity;
        public readonly Vector3D AngularVelocity;
        public MyShipVelocities(Vector3D linearVelocity, Vector3D angularVelocity)
        {
            this = new MyShipVelocities();
            this.LinearVelocity = linearVelocity;
            this.AngularVelocity = angularVelocity;
        }
    }
}


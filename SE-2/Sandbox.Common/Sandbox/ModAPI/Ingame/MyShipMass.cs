namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyShipMass
    {
        public readonly float BaseMass;
        public readonly float TotalMass;
        public readonly float PhysicalMass;
        public MyShipMass(float mass, float totalMass, float physicalMass)
        {
            this.BaseMass = mass;
            this.TotalMass = totalMass;
            this.PhysicalMass = physicalMass;
        }
    }
}


namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyQuad
    {
        public Vector3 Point0;
        public Vector3 Point1;
        public Vector3 Point2;
        public Vector3 Point3;
    }
}


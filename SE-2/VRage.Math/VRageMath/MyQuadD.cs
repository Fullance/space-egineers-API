namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyQuadD
    {
        public Vector3D Point0;
        public Vector3D Point1;
        public Vector3D Point2;
        public Vector3D Point3;
    }
}


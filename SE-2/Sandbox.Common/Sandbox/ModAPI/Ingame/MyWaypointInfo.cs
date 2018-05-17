namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyWaypointInfo
    {
        public readonly string Name;
        public readonly Vector3D Coords;
        public MyWaypointInfo(string name, Vector3D coords)
        {
            this.Name = name;
            this.Coords = coords;
        }
    }
}


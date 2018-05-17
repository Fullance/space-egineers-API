namespace VRage.Game.ModAPI.Interfaces
{
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct MoveInformation
    {
        public Vector3 MoveIndicator;
        public Vector2 RotationIndicator;
        public float RollIndicator;
    }
}


namespace VRageMath
{
    using System;
    using System.Runtime.CompilerServices;

    public static class Vector3Extensions
    {
        public static Vector3 Project(this Vector3 projectedOntoVector, Vector3 projectedVector) => 
            ((Vector3) ((Vector3.Dot(projectedVector, projectedOntoVector) / projectedOntoVector.LengthSquared()) * projectedOntoVector));
    }
}


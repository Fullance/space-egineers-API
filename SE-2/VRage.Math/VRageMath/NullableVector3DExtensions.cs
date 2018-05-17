namespace VRageMath
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class NullableVector3DExtensions
    {
        [Conditional("DEBUG")]
        public static void AssertIsValid(this Vector3D? value)
        {
        }

        public static bool IsValid(this Vector3D? value)
        {
            if (value.HasValue)
            {
                return value.Value.IsValid();
            }
            return true;
        }
    }
}

